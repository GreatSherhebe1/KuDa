using AutoMapper;
using KuDa.Server.DTO;
using KuDa.Server.Services.Interfaces;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IMapper mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserResponse?> GetUserByIDAsync(int id, CancellationToken token)
        {
            var user = await repository.GetByIDAsync(id, token);
            if (user == null)
                return null;

            return mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken token)
        {
            return await repository.GetAllAsync(token);
        }

        public Task<UserResponse> CreateUserAsync(UserRequest request, CancellationToken token)
        {

        }

        public Task<UserResponse?> UpdateUserAsync(int id, UserRequest update, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
