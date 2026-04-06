using KuDa.Server.DTO;

namespace KuDa.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> GetUserByIDAsync(int id, CancellationToken token);
        Task<IEnumerable<UserResponse>> GetAllUsersAsync(CancellationToken token);
        Task<UserResponse> CreateUserAsync(UserRequest request, CancellationToken token);
        Task<UserResponse?> UpdateUserAsync(int id, UserRequest update, CancellationToken token);
        Task<bool> DeleteUserAsync(int id, CancellationToken token);
    }
}
