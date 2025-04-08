using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models;
using AutoMapper;

namespace API.Utils
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Users, GetUserDTO>();
        }
        
    }
}