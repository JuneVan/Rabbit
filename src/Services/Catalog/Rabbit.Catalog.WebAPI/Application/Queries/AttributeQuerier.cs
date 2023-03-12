using Attribute = Rabbit.Catalog.AggregateModels.AttributeAggregate.Attribute;

namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public class AttributeQuerier : IAttributeQuerier
    {
        private readonly IRepository<Attribute> _attributeRepository;
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        public AttributeQuerier(IRepository<Attribute> attributeRepository, IMapper mapper, IThreadSignal  signal)
        {
            _attributeRepository = attributeRepository;
            _mapper = mapper;
            _signal = signal;
        }
        public async Task<BasicAttributeModel> GetBasicAttributeByIdAsync(int id)
        {
            var attribute = await _attributeRepository.IncludingFirstOrDefaultAsync(id, x => x.Options);
            if (attribute == null)
                throw new EntityNotFoundException(typeof(Attribute), id);
            return _mapper.Map<BasicAttributeModel>(attribute);
        }
        public async Task<SalesAttributeModel> GetSalesAttributeByIdAsync(int id)
        {
            var attribute = await _attributeRepository.IncludingFirstOrDefaultAsync(id, x => x.Options);
            if (attribute == null)
                throw new EntityNotFoundException(typeof(Attribute), id);
            return _mapper.Map<SalesAttributeModel>(attribute);
        }
        public async Task<PagedResultDto<AttributeListModel>> GetAttributesAsync(GetAttributesInput input)
        {
            var query = _attributeRepository.GetAll();


            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var attributes = await query.OrderBy(input.Sorting)
                    .Skip((input.PageIndex - 1) * input.PageSize)
                    .Take(input.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<AttributeListModel>(totalCount, _mapper.Map<List<AttributeListModel>>(attributes));
        }
    }
}
