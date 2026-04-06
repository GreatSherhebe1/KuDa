namespace KuDa.Server.DTO
{
    public record TransactionResponse(
        int ID,
        string Description,
        decimal Amount,
        DateTime Date,

        int CategoryID,
        int GroupID,
        int UserID,
        
        DateTime CreatedAt);
}
