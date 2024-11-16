using AutoMapper;
using Server.Core.Entities;
using SkajApp.ApiService.Application.DTOs;

namespace SkajApp.ApiService.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>(); 
            CreateMap<CreateUserRequest, User>();
        }
    }
}