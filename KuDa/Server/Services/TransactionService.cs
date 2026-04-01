using KuDa.Server.DTO;

namespace KuDa.Server.Services
{
    public class TransactionService : ITransactionService
    {
        public Task<TransactionResponse> CreateTransactionAsync(TransationRequest dto, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionResponse>> GetAllProductsAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse?> GetTransactionByIDAsync(int ID, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionResponse> UpdateTransactionAsync(TransationRequest dto, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
