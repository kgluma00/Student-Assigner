using SA.Core.Dtos;
using SA.Core.Entites;
using SA.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.Core.Interfaces
{
    public interface ISaRepository
    {
        Task<int> AddAsyncEntity<T>(List<T> entites) where T : class;
        Task<User> Login(User user);
        Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(byte courseId);
        Task<Student> GetStudentById(int userId);
        void SaveStudentChoices(int[] choices, int userId);
        Task<ICollection<AssignedStudetnsDto>> GetAssignedStudents(int professorId);
        Task<MyResultDto> MyResults(int userId);
        Task<List<Course>> GetAllCourses();
        Task<List<UserDto>> GetAllStudentsByCoursesId(byte courseId);
        Task<List<User>> GetAllProfessorChoicesByStudentId(int studentId);
    }
}
