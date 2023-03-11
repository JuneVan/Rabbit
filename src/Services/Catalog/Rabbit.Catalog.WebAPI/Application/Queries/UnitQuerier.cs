using Unit = Rabbit.Catalog.AggregateModels.UnitAggregate.Unit;

namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public class UnitQuerier : IUnitQuerier
    {
        private readonly IRepository<Unit> _unitRepository;
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        public UnitQuerier(IRepository<Unit> unitRepository,
            IMapper mapper,
            IThreadSignal signal)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _signal = signal;
        }
        public async Task<UnitModel> GetUnitByIdAsync(int id)
        {
            var unit = await _unitRepository.FirstOrDefaultAsync(id);
            return _mapper.Map<UnitModel>(unit);
        }

        public async Task<List<ComboboxItemDto>> GetUnitItemsAsync()
        {
            var unitItems = await (from a in _unitRepository.GetAll()
                                   select new ComboboxItemDto(a.Id, a.Name))
                                 .ToListAsync(_signal.CancellationToken);
            return unitItems;
        }

        public async Task<PagedResultDto<UnitListModel>> GetUnitsAsync(GetUnitsInput input)
        {
            var query = _unitRepository.GetAll();


            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var units = await query.OrderBy(input.Sorting)
                    .Skip((input.PageIndex - 1) * input.PageSize)
                    .Take(input.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<UnitListModel>(totalCount, _mapper.Map<List<UnitListModel>>(units));
        }
    }
}
