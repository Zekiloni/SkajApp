using AutoMapper;
using Server.Core.Entities;
using Shared.DTOs;

namespace Server.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>(); 
            CreateMap<CreateUserReq, User>();
        }
    }
}