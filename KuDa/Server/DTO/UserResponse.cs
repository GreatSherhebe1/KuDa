using System.ComponentModel.DataAnnotations;

namespace KuDa.Server.DTO
{
    public record UserResponse(
        [Required] int id,
        [Required, MinLength(3), MaxLength(64)] string name,
        [Required] string email,
        DateTime cretedAt);
}
