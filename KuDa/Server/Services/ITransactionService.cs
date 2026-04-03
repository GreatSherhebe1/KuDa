using KuDa.Server.DTO;
using System.Linq.Expressions;

namespace KuDa.Server.Services
{
    public interface ITransactionService
    {
        Task<TransactionResponse?> GetTransactionByIDAsync(int ID, CancellationToken token = default);
        Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync(CancellationToken token = default);
        Task<TransactionResponse> CreateTransactionAsync(TransationRequest dto, CancellationToken token = default);
        Task<TransactionResponse> UpdateTransactionAsync(TransationRequest dto, CancellationToken token = default);
        Task<bool> DeleteTransactionAsync(int id, CancellationToken token = default);
    }
}
