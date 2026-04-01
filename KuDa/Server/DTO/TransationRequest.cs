namespace KuDa.Server.DTO
{
    public record TransationRequest(
        int ID,
        string Description,
        decimal Amount,
        DateTime Date,

        int CategoryID,
        int GroupID,
        int UserID);
}
