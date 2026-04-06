using KuDa.Server.DTO;

namespace KuDa.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync(CancellationToken token);
        Task<UserDTO?> GetUserByIDAsync(int id, CancellationToken token);
        Task<UserDTO> CreateUserAsync(CreateUserRequest request, CancellationToken token);
        Task<UserDTO?> UpdateUserAsync(int id, UpdateUserRequest update, CancellationToken token);
        Task<bool> DeleteUserAsync(int id, CancellationToken token);
    }
}
