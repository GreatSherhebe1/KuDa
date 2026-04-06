using System.ComponentModel.DataAnnotations;

namespace KuDa.Server.DTO
{
    public record UserRequest(
        int id,
        [Required, MinLength(3), MaxLength(64)] string name,
        [Required] string email);
}
