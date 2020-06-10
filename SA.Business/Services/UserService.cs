using AutoMapper;
using SA.Business.Interfaces;
using SA.Core.Entites;
using SA.Core.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<User> Login(User user)
        {
            return await _saRepository.Login(user);
        }
    }
}
