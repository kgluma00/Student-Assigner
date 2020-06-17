using AutoMapper;
using SA.Core.Dtos;
using SA.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sa.Repository.Mappings
{
    public class SaRepositoryMappingProfile : Profile
    {
        public SaRepositoryMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Professor, ProfessorDto>().ReverseMap();
            CreateMap<Course, CoursesDto>().ReverseMap();
        }
    }
}
