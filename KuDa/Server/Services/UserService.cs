using KuDa.Server.DTO;
using KuDa.Server.Services.Interfaces;
using Model.Entities;
using Model.Interfaces;

namespace KuDa.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserRequest request, CancellationToken token)
        {
            var task = new Task<UserDTO>(() =>
            {

            });
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO?> GetUserByIDAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO?> UpdateUserAsync(int id, UpdateUserRequest update, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
