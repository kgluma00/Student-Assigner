﻿using AutoMapper;
using SA.Business.Interfaces;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
using SA.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ISaRepository _saRepository;

        public UserService(ISaRepository saRepository, IMapper mapper)
        {
            _mapper = mapper;
            _saRepository = saRepository;
        }

        public async Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(int userId)
        {
            var user = await _saRepository.GetStudentById(userId);
            if (user == null) return null;
            var professors = await _saRepository.GetProfessorsByCourse(user.CourseId);

            return professors;
        }

        public async Task<User> Login(User user)
        {
            return await _saRepository.Login(user);
        }

        public async Task<MyResultDto> MyResults(int userId)
        {
            return await _saRepository.MyResults(userId);
        }

        public void SaveStudentChoices(string[] choices, int userId)
        {
            var cvChoices = choices.Select(int.Parse).ToArray();
            _saRepository.SaveStudentChoices(cvChoices, userId);
        }

        public async Task<ICollection<AssignedStudetnsDto>> GetAssignedStudents(int professorId)
        {
            return await _saRepository.GetAssignedStudents(professorId);
        }

        public async Task<List<CoursesDto>> GetAllCourses()
        {
            var coursesFromDb = await _saRepository.GetAllCourses();
            return _mapper.Map<List<Course>, List<CoursesDto>>(coursesFromDb);
        }

        public async Task<List<UserDto>> GetAllStudentsByCoursesId(byte courseId)
        {
            return await _saRepository.GetAllStudentsByCoursesId(courseId);
        }

        public async Task<StudentProfessorDto> GetAllStudentProfessorDetails(int studentId)
        {
            return await _saRepository.GetAllStudentProfessorDetails(studentId);
        }

        public async Task<bool> GetStudentAssignedInformation(int userId)
        {
            return await _saRepository.GetStudentAssignedInformation(userId);
        }

        public async Task<bool> CheckIfSystemAlgorithmStarted()
        {
            return await _saRepository.CheckIfSystemAlgorithmStarted();
        }

        public async Task<List<StudentInfoDto>> GetAllStudentsAlgorithmInfo()
        {
            var studentInfoDto = await _saRepository.GetAllStudentsAlgorithmInfo();
            CalculatePoints(studentInfoDto);
            studentInfoDto = studentInfoDto.OrderByDescending(p => p.Points).ToList();
            AssignProfessorToStudent(studentInfoDto);

            foreach (var item in studentInfoDto)
            {

            }

            var x = studentInfoDto.Where(p => p.AssignedProfessor == 0).ToList();

            return studentInfoDto;
        }

        private void AssignProfessorToStudent(List<StudentInfoDto> studentInfoDtos)
        {
            foreach (var student in studentInfoDtos)
            {
                foreach (var professor in student.ProfessorDtos)
                {
                    if (CheckProfessorAvailability(professor, student.StudyLevel))
                    {
                        student.AssignedProfessor = professor.UserId;
                        professor.MaxPoints -= student.StudyLevel;
                        break;
                    }
                }
            }
        }

        private bool CheckProfessorAvailability(ProfessorDto professorBasicInfoDto, int studentStudyLevel)
        {
            return (professorBasicInfoDto.MaxPoints - studentStudyLevel >= 0);
        }

        private void CalculatePoints(List<StudentInfoDto> studentInfoDtos)
        {
            foreach (var student in studentInfoDtos)
            {
                if (student.NmbrOfRptYears == 1)
                    student.Points = Math.Round(student.AverageGrade * 80, 4);
                else if (student.NmbrOfRptYears == 2)
                    student.Points = Math.Round(student.AverageGrade * 60, 4);
                else if (student.NmbrOfRptYears == 3)
                    student.Points = Math.Round(student.AverageGrade * 40, 4);
                else
                    student.Points = Math.Round(student.AverageGrade * 100, 4);
            }
        }
    }
}
