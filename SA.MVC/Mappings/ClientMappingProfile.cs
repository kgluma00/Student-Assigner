using AutoMapper;
using SA.Core.Entites;
using SA.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.MVC.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<StudentHomeDto, User>().ReverseMap();
        }
    }
}
