using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models.User;
using AutoMapper;

namespace API.Utils
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Users, GetUserDTO>()
                .ForMember(dest => dest.DataAtualizacao,
                opt => opt.MapFrom(src => src.DataAtualizacao.ToString("dd/MM/yyyy")));

            CreateMap<Users, UpdateUserDTO>();
        }
        
    }
}