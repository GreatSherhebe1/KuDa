using System.ComponentModel.DataAnnotations;

namespace KuDa.Server.DTO
{
    public record CreateUserRequest(
        [Required, MinLength(3), MaxLength(64)] string name,
        [Required] string email);
}
