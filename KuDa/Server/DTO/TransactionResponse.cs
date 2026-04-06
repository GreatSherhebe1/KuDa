using System.ComponentModel.DataAnnotations;

namespace KuDa.Server.DTO
{
    public record TransactionResponse(
        [Required]int ID,
        string Description,
        decimal Amount,
        DateTime Date,

        int CategoryID,
        int GroupID,
        int UserID,
        
        DateTime CreatedAt);
}
