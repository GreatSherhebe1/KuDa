using AutoMapper;
using KuDa.Server.DTO;
using Model.Entities;

namespace KuDa.Server.Mapping
{
    public class TransactionDTOMapper : Profile
    {
        public TransactionDTOMapper() 
        {
            CreateMap<Transaction, TransactionResponse>();
            CreateMap<TransactionResponse, Transaction>();
            CreateMap<TransationRequest, Transaction>();
        }
    }
}
