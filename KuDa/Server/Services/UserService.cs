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
            var users = await repository.GetAllAsync(token);
            return mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> CreateUserAsync(UserRequest dto, CancellationToken token)
        {
            var user = mapper.Map<User>(dto);
            user.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            return mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse?> UpdateUserAsync(UserRequest dto, CancellationToken token)
        {
            var user = await repository.GetByIDAsync(dto.id, token);
            if (user == null)
                return null;

            mapper.Map(dto, user);
            await repository.UpdateAsync(user, token);
            await repository.SaveChangesAsync(token);

            return mapper.Map<UserResponse>(user);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken token)
        {
            var user = await repository.GetByIDAsync(id, token);
            if (user == null)
                return false;

            await repository.Delete(user);
            await repository.SaveChangesAsync(token);
            return true;
        }
    }
}
