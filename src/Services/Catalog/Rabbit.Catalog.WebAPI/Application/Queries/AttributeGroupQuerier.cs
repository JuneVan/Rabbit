namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public class AttributeGroupQuerier : IAttributeGroupQuerier
    {
        private readonly IRepository<AttributeGroup> _attributeGroupRepository;
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        public AttributeGroupQuerier(IRepository<AttributeGroup> attributeGroupRepository,
            IMapper mapper, IThreadSignal signal)
        {

            _attributeGroupRepository = attributeGroupRepository;
            _mapper = mapper;
            _signal = signal;
        }

        public async Task<AttributeGroupModel> GetAttributeGroupByIdAsync(int id)
        {
            var attributeGroup = await _attributeGroupRepository.IncludingFirstOrDefaultAsync(id, x => x.Items);
            return _mapper.Map<AttributeGroupModel>(attributeGroup);
        }

        public async Task<PagedResultDto<AttributeGroupListModel>> GetAttributeGroupsAsync(GetAttributeGroupsInput input)
        {
            var query = _attributeGroupRepository.GetAll().Where(w=>w.CategoryId==input.CategoryId);


            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var attributes = await query.OrderBy(input.Sorting)
                    .Skip((input.PageIndex - 1) * input.PageSize)
                    .Take(input.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<AttributeGroupListModel>(totalCount, _mapper.Map<List<AttributeGroupListModel>>(attributes));
        } 
    }
}
