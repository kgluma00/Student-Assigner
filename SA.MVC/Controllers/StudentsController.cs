using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SA.Business.Interfaces;
using SA.Core.Dtos;
using SA.MVC.Models;

namespace SA.MVC.Controllers
{
    public class StudentsController : Controller
    {
        public IMapper _mapper { get; }
        private readonly IUserService _userService;
        public StudentsController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userHomeDto = new StudentHomeDto();

            var claims = User.Claims.ToList();
            userHomeDto.RoleId = byte.Parse(claims[2].Value);
            userHomeDto.Id = int.Parse(claims[0].Value);

            return View(userHomeDto);
        }

        [HttpGet]
        public async Task<List<ProfessorBasicInfoDto>> GetProfessorsByCourse(int id)
        {
            var professorBasicInfoDtos = await _userService.GetProfessorsByCourse(id);

            return professorBasicInfoDtos;
        }

        [HttpPost]
        public ActionResult SaveStudentsChoices(string[] choices)
        {
            if (choices.Length == 0) return NotFound();
            //var userId = User.Claims.ToList();
            //_userService.SaveStudentChoices(choices, int.Parse(userId[0].Value));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> MyResults()
        {
            var claims = User.Claims.ToList();
            var myResultDto = await _userService.MyResults(int.Parse(claims[0].Value));

            return View(myResultDto);
        }
    }
}
