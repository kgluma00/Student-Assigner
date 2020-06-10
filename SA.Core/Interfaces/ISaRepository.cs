using SA.Core.Dtos;
using SA.Core.Entites;
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

    }
}
