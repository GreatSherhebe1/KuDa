using AutoMapper;
using KuDa.Server.DTO;
using Model.Entities;

namespace KuDa.Server.Mapping
{
    public class UserDTOMapper : Profile
    {
        public UserDTOMapper() 
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<UserRequest, User>();
        }
    }
}
