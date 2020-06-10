using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interfaces;
using SA.Core.Dtos;

namespace SA.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IMapper _mapper { get; }
        private readonly IUserService _userService;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(int id)
        {
            var professorBasicInfoDtos = await _userService.GetProfessorsByCourse(id);

            return professorBasicInfoDtos;
        }
    }
}
