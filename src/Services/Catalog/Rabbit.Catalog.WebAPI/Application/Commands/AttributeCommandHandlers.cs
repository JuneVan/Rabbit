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
            var attribute = new Attribute(request.Name, request.IsRequired, request.DisplayOrder, request.Type, request.DisplayType, request.Description, request.IsSearch);
            if (!request.Options.IsNullOrEmpty())
            {
                foreach (var option in request.Options)
                {
                    attribute.AddOption(option.Name, option.DisplayOrder);
                }
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
            attribute.SetName(request.Name);
            attribute.SetDescription(request.Description);
            attribute.SetDisplayOrder(request.DisplayOrder);
            attribute.SetType(request.Type);
            attribute.SetIsRequired(request.IsRequired);
            attribute.SetDisplayType(request.DisplayType);
            attribute.SetIsSearch(request.IsSearch);
            if (!request.Options.IsNullOrEmpty())
            {
                // 检查新增/更新
                foreach (var option in request.Options)
                {
                    if (!option.Id.HasValue)
                        attribute.AddOption(option.Name, option.DisplayOrder);
                    else
                        attribute.UpdateOption(option.Id.Value, option.Name, option.DisplayOrder);
                }
            }
            if (!attribute.Options.IsNullOrEmpty())
            {
                // 检查删除
                foreach (var option in attribute.Options)
                {
                    if (request.Options.Find(x => x.Id == option.Id) == null)
                        attribute.RemoveOption(option.Id);
                }
            }

            await _attributeRepository.UpdateAsync(attribute);
            await _attributeRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _attributeRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Options);
            if (attribute == null)
                throw new EntityNotFoundException(typeof(Attribute), request.Id);
            // TODO:检查商品引用
            // TODO:检查分类引用
            await _attributeRepository.DeleteAsync(attribute);
            await _attributeRepository.UnitOfWork.CommitAsync();
        }
    }
}
