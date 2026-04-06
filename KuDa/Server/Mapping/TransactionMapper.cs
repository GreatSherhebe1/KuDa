using AutoMapper;
using KuDa.Server.DTO;
using Model.Entities;

namespace KuDa.Server.Mapping
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper() 
        {
            CreateMap<Transaction, TransactionResponse>();
            CreateMap<TransactionResponse, Transaction>();
            CreateMap<TransationRequest, Transaction>();
        }
    }
}
