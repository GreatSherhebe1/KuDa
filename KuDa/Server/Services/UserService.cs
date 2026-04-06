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

        public async Task<UserDTO?> GetUserByIDAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserRequest request, CancellationToken token)
        {
        }

        public async Task<UserDTO?> UpdateUserAsync(int id, UpdateUserRequest update, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
