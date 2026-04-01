using KuDa.Server.DTO;

namespace KuDa.Server.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionResponse>> GetAllProductsAsync(CancellationToken token = default);
        Task<TransactionResponse?> GetTransactionByIDAsync(int ID, CancellationToken token = default);
        Task<TransactionResponse> CreateTransactionAsync(TransationRequest dto, CancellationToken token = default);
        Task<TransactionResponse> UpdateTransactionAsync(TransationRequest dto, CancellationToken token = default);
        Task<bool> DeleteTransactionAsync(int id, CancellationToken token = default);
    }
}
