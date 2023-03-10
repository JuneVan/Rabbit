using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class AttributeCommandHandlers : IRequestHandler<CreateAttributeCommand, int>, IRequestHandler<UpdateAttributeCommand>, IRequestHandler<DeleteAttributeCommand>
    {
        private readonly IRepository<Attribute> _attributeRepository;
        public AttributeCommandHandlers(IRepository<Attribute> attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }
        public async Task<int> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = new Attribute(request.Name, request.IsRequired, request.DisplayOrder, request.DisplayType);
            foreach (var option in request.Options)
            {
                attribute.AddOption(option.Name, option.DisplayOrder);
            }
            var attributeId = await _attributeRepository.InsertAndGetIdAsync(attribute);
            await _attributeRepository.UnitOfWork.CommitAsync();
            return attributeId;
        }

        public async Task Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Options);
            if (attribute == null)
                throw new EntityNotFoundException(typeof(Attribute), request.Id);

            // 检查新增/更新
            foreach (var option in request.Options)
            {
                if (!option.Id.HasValue)
                    attribute.AddOption(option.Name, option.DisplayOrder);
                else
                    attribute.UpdateOption(option.Id.Value, option.Name, option.DisplayOrder);
            }
            // 检查删除
            foreach (var option in attribute.Options)
            {
                if (request.Options.Find(x => x.Id == option.Id) == null)
                    attribute.RemoveOption(option.Id);
            }
            await _attributeRepository.UpdateAsync(attribute);
            await _attributeRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Options);
            if (attribute == null)
                throw new EntityNotFoundException(typeof(Attribute), request.Id);
            await _attributeRepository.DeleteAsync(attribute);
            await _attributeRepository.UnitOfWork.CommitAsync();
        }
    }
}
