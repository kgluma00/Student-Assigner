using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interfaces;

namespace SA.MVC.Controllers
{
    public class ProfessorsController : Controller
    {
        public IMapper _mapper { get; }
        private readonly IUserService _userService;

        public ProfessorsController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var claims = User.Claims.ToList();
            var assignedStudents = await _userService.GetAssignedStudents(int.Parse(claims[0].Value));

            return View(assignedStudents);
        }
    }
}