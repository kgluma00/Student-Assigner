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
        Task<int> UpdateAsyncStudentEntity(List<Student> students);
        Task<int> UpdateAsyncProfessorEntity(List<Professor> professor);
        Task<User> Login(User user);
        Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(byte courseId);
        Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourseAndMaxPoints(byte courseId);
        Task<Student> GetStudentById(int userId);
        void SaveStudentChoices(int[] choices, int userId);
        Task<ICollection<AssignedStudetnsDto>> GetAssignedStudents(int professorId);
        Task<MyResultDto> MyResults(int userId);
        Task<List<Course>> GetAllCourses();
        Task<List<UserDto>> GetAllStudentsByCoursesId(byte courseId);
        Task<StudentProfessorDto> GetAllStudentProfessorDetails(int userId);
        Task<bool> GetStudentAssignedInformation(int userId);
        Task<bool> CheckIfSystemAlgorithmStarted();
        Task<List<StudentInfoDto>> GetAllStudentsAlgorithmInfo();
        Task<int> CountUnassignedStudents();
        Task<List<StudentUserDto>> GetUnassignedStudentsByCourseId(byte courseId);
        Task<int> SaveStudentChoiceByAdminDecision(int studentId, int assignedProfessorId);
    }
}
