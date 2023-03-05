namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IRoleQuerier
    {
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<PagedResultDto<RoleListModel>> GetRolesAsync(GetRolesQuery query);
        Task<IEnumerable<ComboboxItemDto>> GetRoleItemsAsync();
    }
    public class RoleQuerier : IRoleQuerier
    {
        private readonly IRepository<Role> _roleRepository;
        private readonly IThreadSignal _signal;
        private readonly IMapper _mapper;
        public RoleQuerier(IRepository<Role> roleRepository,
            IThreadSignal signal,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _signal = signal;
            _mapper = mapper;
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.IncludingFirstOrDefaultAsync(id, x => x.Permissions);
            return _mapper.Map<RoleModel>(role);
        }

        public async Task<IEnumerable<ComboboxItemDto>> GetRoleItemsAsync()
        {
            var roleItems = await (from a in _roleRepository.GetAll()
                                   where a.IsActive
                                   select new ComboboxItemDto()
                                   {
                                       Value = a.Id,
                                       Text = a.Name
                                   }).ToListAsync(_signal.CancellationToken);
            return roleItems;
        }

        public async Task<PagedResultDto<RoleListModel>> GetRolesAsync(GetRolesQuery request)
        {
            var query = _roleRepository.GetAll();
            if (!request.Name.IsNullOrEmpty())
                query = query.Where(w => w.Name.Contains(request.Name));

            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var roles = await query.OrderBy(request.Sorting)
                    .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<RoleListModel>(totalCount, _mapper.Map<List<RoleListModel>>(roles));
        }
    }
}
