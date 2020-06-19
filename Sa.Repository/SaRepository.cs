using Microsoft.EntityFrameworkCore;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
using SA.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public async Task<int> UpdateAsyncEntity(List<Student> students)
        {
            foreach (var student in students)
            {
                _applicationContext.Students.Attach(student);
                _applicationContext.Entry(student).Property(x => x.AssignedProfessor).IsModified = true;
                _applicationContext.Entry(student).Property(x => x.Points).IsModified = true;
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

        public async Task<StudentProfessorDto> GetAllStudentProfessorDetails(int userId)
        {
            var studentUserDto = await (from spc in _applicationContext.StudentProfessorChoices
                                        join s in _applicationContext.Students
                                        on spc.StudentId equals s.UserId
                                        join u in _applicationContext.Users
                                        on s.UserId equals u.Id
                                        where spc.StudentId == userId
                                        select new StudentUserDto
                                        {
                                            UserId = userId,
                                            FirstName = u.FirstName,
                                            LastName = u.LastName,
                                            Email = u.Email,
                                            CountryOfBirth = u.CountryOfBirth,
                                            AverageGrade = s.AverageGrade,
                                            StudyLevel = s.StudyLevel,
                                            Comment = s.Comment,
                                            Points = s.Points,
                                            NmbrOfRptYears = s.NmbrOfRptYears
                                        }).Distinct().FirstOrDefaultAsync();

            var professorBasicInfoDto = await (from spc in _applicationContext.StudentProfessorChoices
                                               join p in _applicationContext.Professors
                                               on spc.ProfessorId equals p.UserId
                                               join u in _applicationContext.Users
                                               on p.UserId equals u.Id
                                               where spc.StudentId == userId
                                               select new ProfessorBasicInfoDto
                                               {
                                                   Id = spc.ProfessorId,
                                                   FirstName = u.FirstName,
                                                   LastName = u.LastName,
                                                   Email = u.Email,
                                                   AreaOfInterestOne = p.AreaOfInterestOne,
                                                   AreaOfInterestTwo = p.AreaOfInterestTwo,
                                                   AreaOfInterestThree = p.AreaOfInterestThree
                                               }).ToListAsync();

            var assignedProfessorBasicInfoDto = await (from s in _applicationContext.Students
                                                       join p in _applicationContext.Professors
                                                       on s.AssignedProfessor equals p.UserId
                                                       join u in _applicationContext.Users
                                                       on p.UserId equals u.Id
                                                       where s.UserId == userId
                                                       select new ProfessorBasicInfoDto
                                                       {
                                                           Id = s.AssignedProfessor.Value,
                                                           FirstName = u.FirstName,
                                                           LastName = u.LastName,
                                                           Email = u.Email,
                                                           AreaOfInterestOne = p.AreaOfInterestOne,
                                                           AreaOfInterestTwo = p.AreaOfInterestTwo,
                                                           AreaOfInterestThree = p.AreaOfInterestThree
                                                       }).FirstOrDefaultAsync();

            return new StudentProfessorDto
            {
                StudentUserDto = studentUserDto,
                ProfessorBasicInfoDto = professorBasicInfoDto,
                AssignedProfessorBasicInfoDto = assignedProfessorBasicInfoDto
            };
        }

        public async Task<bool> GetStudentAssignedInformation(int userId)
        {
            return await _applicationContext.StudentProfessorChoices.Where(u => u.StudentId == userId).AnyAsync();
        }

        public async Task<bool> CheckIfSystemAlgorithmStarted()
        {
            return await _applicationContext.Students.AnyAsync(ap => ap.AssignedProfessor != null);
        }

        public async Task<List<StudentInfoDto>> GetAllStudentsAlgorithmInfo()
        {
            var studentsInfo = await (from s in _applicationContext.Students
                                      select new StudentInfoDto
                                      {
                                          Id = s.Id,
                                          UserId = s.UserId,
                                          AverageGrade = s.AverageGrade,
                                          NmbrOfRptYears = s.NmbrOfRptYears,
                                          StudyLevel = s.StudyLevel,
                                          Points = s.Points,
                                          AssignedProfessor = s.AssignedProfessor.Value,
                                          ProfessorDtos = null
                                      }).ToListAsync();

            var professors = await (from p in _applicationContext.Professors
                                   select new ProfessorDto
                                   {
                                       Id = p.Id,
                                       UserId = p.UserId,
                                       MaxPoints = p.MaxPoints
                                   }).ToListAsync();

            var choices = await _applicationContext.StudentProfessorChoices.ToListAsync();

            foreach (var student in studentsInfo)
            {
                var professorIds = choices.Where(c => c.StudentId == student.UserId).Select(c => c.ProfessorId);
                student.ProfessorDtos = professors.Where(p => professorIds.Contains(p.UserId)).ToList();
            }

            return studentsInfo;
        }

        public async Task<int> CountUnassignedStudents()
        {
            var unAssignedStudents = await _applicationContext.Students.Where(ap => ap.AssignedProfessor == 0).ToListAsync();

            return unAssignedStudents.Count;
        }

        public async Task<List<StudentUserDto>> GetUnassignedStudentsByCourseId(byte courseId)
        {

            return await (from s in _applicationContext.Students
                                            join u in _applicationContext.Users
                                            on s.UserId equals u.Id
                                            where s.CourseId == courseId && s.AssignedProfessor == 0
                                            select new StudentUserDto
                                            {
                                                FirstName = u.FirstName,
                                                LastName =  u.LastName,
                                                UserId = s.UserId,
                                                AverageGrade = s.AverageGrade,
                                                NmbrOfRptYears = s.NmbrOfRptYears,
                                                Comment = s.Comment
                                            }
                                            ).ToListAsync();

        }
    }
}
