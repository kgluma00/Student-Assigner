﻿using SA.Core.Dtos;
using SA.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(User user);
        Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(int userId);
    }
}
