using Microsoft.EntityFrameworkCore;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
using SA.MVC.Models;
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

        public async Task<MyResultDto> MyResults(int userId)
        {
            var studentInfo = await (from s in _applicationContext.Students
                                     join c in _applicationContext.Courses
                                     on s.CourseId equals c.Id
                                     where s.UserId == userId
                                     select new StudentInfoDto
                                     {
                                         UserId = userId,
                                         AverageGrade = s.AverageGrade,
                                         CourseName = c.CourseName,
                                         NmbrOfRptYears = s.NmbrOfRptYears,
                                         Comment = s.Comment,
                                         StudyLevel = s.StudyLevel,
                                         AssignedProfessor = s.AssignedProfessor.Value
                                     }).FirstOrDefaultAsync();

            var professorInfo = await (from u in _applicationContext.Users
                                       join p in _applicationContext.Professors
                                       on u.Id equals p.UserId
                                       where u.Id == studentInfo.AssignedProfessor
                                       select new ProfessorInfoDto
                                       {
                                           UserId = studentInfo.AssignedProfessor,
                                           FirstName = u.FirstName,
                                           LastName = u.LastName,
                                           AreaOfInterestOne = p.AreaOfInterestOne,
                                           AreaOfInterestTwo = p.AreaOfInterestTwo,
                                           AreaOfInterestThree = p.AreaOfInterestThree,
                                           Email = u.Email
                                       }).FirstOrDefaultAsync();

            return new MyResultDto { ProfessorInfo = professorInfo, StudentInfo = studentInfo };
        }

        public void SaveStudentChoices(int[] choices, int userId)
        {
            var spChoices = choices.Select((c, i) => new StudentProfessorChoices() { StudentId = userId, ProfessorId = c, Factor = (byte)(i + 1) });
            _applicationContext.StudentProfessorChoices.AddRange(spChoices);
            _applicationContext.SaveChanges();
        }

        public async Task<ICollection<AssignedStudetnsDto>> GetAssignedStudents(int professorId)
        {
            //var assignedStudents = await _applicationContext.Students.Where(s => s.AssignedProfessor == professorId).ToListAsync();

            return await (from u in _applicationContext.Users
                          join s in _applicationContext.Students
                          on u.Id equals s.UserId
                          where s.AssignedProfessor == professorId
                          orderby s.Points descending, s.StudyLevel descending
                          select new AssignedStudetnsDto
                          {
                              StudentFirstName = u.FirstName,
                              StudentLastName = u.LastName,
                              CourseId = s.CourseId,
                              AverageGrade = s.AverageGrade,
                              StudyLevel = s.StudyLevel,
                              Comment = s.Comment
                          }).ToListAsync();
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _applicationContext.Courses.ToListAsync();
        }

        public async Task<List<UserDto>> GetAllStudentsByCoursesId(byte courseId)
        {
            var userFromDb = await (from s in _applicationContext.Students
                                    join u in _applicationContext.Users
                                    on s.UserId equals u.Id
                                    where s.CourseId == courseId
                                    select new UserDto
                                    {
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        StudentId = s.Id,
                                        Id = u.Id
                                    }).ToListAsync();

            return userFromDb;
        }

        public Task<List<User>> GetAllProfessorChoicesByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
