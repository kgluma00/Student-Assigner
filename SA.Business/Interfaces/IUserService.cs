using SA.Core.Dtos;
using SA.Core.Entites;
using SA.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> Login(User user);
        Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(int userId);
        void SaveStudentChoices(string[] choices, int userId);
        Task<MyResultDto> MyResults(int userId);
       
    }
}
