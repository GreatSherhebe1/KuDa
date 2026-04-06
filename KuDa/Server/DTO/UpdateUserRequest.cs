using System.ComponentModel.DataAnnotations;

namespace KuDa.Server.DTO
{
    public record UpdateUserRequest(
        [Required, MinLength(3), MaxLength(64)] string name,
        [Required] string email);
}
