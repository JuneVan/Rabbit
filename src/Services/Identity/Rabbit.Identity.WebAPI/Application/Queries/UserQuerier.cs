namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IUserQuerier
    {
        Task<UserModel> GetUserByIdAsync(int id);
        Task<PagedResultDto<UserListModel>> GetUsersAsync(GetUsersQuery query);
        Task<IEnumerable<ComboboxItemDto>> GetUserItemsAsync();
    }
    public class UserQuerier : IUserQuerier
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        public UserQuerier(IRepository<User> userRepository,
            IMapper mapper,
            IThreadSignal signal)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _signal = signal;
        }
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.IncludingFirstOrDefaultAsync(id, x => x.Roles);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<IEnumerable<ComboboxItemDto>> GetUserItemsAsync()
        {
            var users = await (from a in _userRepository.GetAll()
                               where a.IsActive
                               select new ComboboxItemDto(a.Id, a.Username)).ToListAsync(_signal.CancellationToken);
            return users;
        }

        public async Task<PagedResultDto<UserListModel>> GetUsersAsync(GetUsersQuery request)
        {

            var query = _userRepository.GetAll();
            if (!request.Username.IsNullOrEmpty())
                query = query.Where(w => w.Username.Contains(request.Username));

            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var users = await query.OrderBy(request.Sorting)
                    .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<UserListModel>(totalCount, _mapper.Map<List<UserListModel>>(users));
        }
    }
}
