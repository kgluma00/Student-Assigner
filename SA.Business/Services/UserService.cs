using AutoMapper;
using SA.Business.Interfaces;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
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

        public void SaveStudentChoices(string[] choices, int userId)
        {
            var cvChoices = choices.Select(int.Parse).ToArray();
            _saRepository.SaveStudentChoices(cvChoices, userId);
        }
    }
}
