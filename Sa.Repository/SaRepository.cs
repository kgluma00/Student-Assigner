using Microsoft.EntityFrameworkCore;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa.Repository
{
    public class SaRepository : ISaRepository
    {
        private readonly ApplicationContext _applicationContext;
        public SaRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

        }

        public async Task<int> AddAsyncEntity<T>(List<T> entites) where T : class
        {
            foreach (var el in entites)
            {
                _applicationContext.Add(el);
            }

            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(byte courseId)
        {
            return await (from p in _applicationContext.Professors
                          join u in _applicationContext.Users
                          on p.UserId equals u.Id
                          where p.CourseId == courseId
                          select new ProfessorBasicInfoDto
                          {
                              Id = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              AreaOfInterestOne = p.AreaOfInterestOne,
                              AreaOfInterestTwo = p.AreaOfInterestTwo,
                              AreaOfInterestThree = p.AreaOfInterestThree
                          }
                      ).ToListAsync();
        }

        public async Task<Student> GetStudentById(int userId)
        {
            var userFromDb = await _applicationContext.Students.Where(i => i.UserId == userId).FirstOrDefaultAsync();

            return userFromDb;
        }

        public async Task<User> Login(User user)
        {
            var userFromDb = await _applicationContext.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            return userFromDb;
        }

        public void SaveStudentChoices(int[] choices, int userId)
        {
            var spChoices = choices.Select((c, i) => new StudentProfessorChoices() { StudentId = userId, ProfessorId = c, Factor = (byte)(i + 1) });
            _applicationContext.StudentProfessorChoices.AddRange(spChoices);
            _applicationContext.SaveChanges();
        }
    }
}
