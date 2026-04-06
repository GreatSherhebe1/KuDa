using AutoMapper;
using KuDa.Server.DTO;
using KuDa.Server.Mapping;
using KuDa.Server.Repositories;
using Model.Entities;
using System.Linq.Expressions;
using Transaction = Model.Entities.Transaction;

namespace KuDa.Server.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionRepository repository;
        private readonly IMapper mapper;

        public TransactionService(TransactionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TransactionResponse?> GetTransactionByIDAsync(int ID, CancellationToken token = default)
        {
            var transaction = await repository.GetByIDAsync(ID, token);
            return transaction == null ? null : mapper.Map<TransactionResponse>(transaction);
        }

        public async Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync(CancellationToken token = default)
        {
            var transactions = await repository.GetAllAsync(token);
            return mapper.Map<IEnumerable<TransactionResponse>>(transactions);
        }

        public async Task<TransactionResponse> CreateTransactionAsync(TransationRequest dto, CancellationToken token = default)
        {
            var transaction = mapper.Map<Transaction>(dto);
            transaction.CreatedAt = DateTime.UtcNow;

            await repository.AddAsync(transaction, token);
            await repository.SaveChangesAsync(token);

            return mapper.Map<TransactionResponse>(transaction);
        }

        public async Task<TransactionResponse> UpdateTransactionAsync(TransationRequest dto, CancellationToken token = default)
        {
            var transaction = mapper.Map<Transaction>(dto);

            await repository.UpdateAsync(transaction, token);
            await repository.SaveChangesAsync(token);

            return mapper.Map<TransactionResponse>(transaction);
        }

        public async Task<bool> DeleteTransactionAsync(int id, CancellationToken token = default)
        {
            var transaction = await repository.GetByIDAsync(id, token);
            if (transaction == null)
                return false;

            repository.Delete(transaction);
            await repository.SaveChangesAsync(token);
            return true;
        }
    }
}
