using Rabbit.Threading;

namespace Rabbit.Catalog.WebAPI.Application.Queries
{
    public class BrandQuerier : IBrandQuerier
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        public BrandQuerier(IRepository<Brand> brandRepository, IMapper mapper, IThreadSignal signal)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _signal = signal;

        }
        public async Task<BrandModel> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.FirstOrDefaultAsync(id);
            return _mapper.Map<BrandModel>(brand);
        }

        public async Task<PagedResultDto<BrandListModel>> GetBrandsAsync(GetBrandsInput input)
        {
            var query = _brandRepository.GetAll();
            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var brands = await query.OrderBy(input.Sorting)
                    .Skip((input.PageIndex - 1) * input.PageSize)
                    .Take(input.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<BrandListModel>(totalCount, _mapper.Map<List<BrandListModel>>(brands));
        }
    }
}
