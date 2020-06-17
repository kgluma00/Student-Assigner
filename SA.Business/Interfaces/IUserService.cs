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
        Task<ICollection<AssignedStudetnsDto>> GetAssignedStudents(int professorId);
        Task<MyResultDto> MyResults(int userId);
        Task<List<CoursesDto>> GetAllCourses();
        Task<List<UserDto>> GetAllStudentsByCoursesId(byte courseId);
        Task<StudentProfessorDto> GetAllStudentProfessorDetails(int studentId);
    }
}
