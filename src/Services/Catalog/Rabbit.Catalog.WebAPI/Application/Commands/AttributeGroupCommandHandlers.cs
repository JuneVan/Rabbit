namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class AttributeGroupCommandHandlers : IRequestHandler<CreateAttributeGroupCommand, int>, IRequestHandler<UpdateAttributeGroupCommand>, IRequestHandler<DeleteAttributeGroupCommand>
    {
        private readonly IRepository<AttributeGroup> _attributeGroupRepository;
        public AttributeGroupCommandHandlers(IRepository<AttributeGroup> attributeGroupRepository)
        {
            _attributeGroupRepository = attributeGroupRepository;

        }
        public async Task<int> Handle(CreateAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            var attributeGroup = new AttributeGroup(request.Name, request.CategoryId);

            if (!request.Items.IsNullOrEmpty())
            {
                foreach (var item in request.Items)
                {
                    attributeGroup.AddItem(item.AttributeId, item.DisplayOrder);
                }
            }
            var templateId = await _attributeGroupRepository.InsertAndGetIdAsync(attributeGroup);
            await _attributeGroupRepository.UnitOfWork.CommitAsync();
            return templateId;
        }

        public async Task Handle(UpdateAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            var template = await _attributeGroupRepository.IncludingFirstOrDefaultAsync(request.Id, x => x.Items);

            throw new NotImplementedException();
        }

        public Task Handle(DeleteAttributeGroupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
