using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interfaces;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;
using SA.MVC.Models;

namespace SA.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IMapper _mapper { get; }
        private readonly IUserService _userService;

        public HomeController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var user = await _userService.Login(_mapper.Map<LoginDto, User>(dto));

            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.RoleId.ToString()),
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            await HttpContext.SignInAsync(userPrincipal);

            //var professorsDto = await _userService.GetProfessorsByCourse(user.Id);

            return View("Index", _mapper.Map<User, UserHomeDto>(user));
        }
    }
}
