using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interfaces;
using SA.Core.Entites;
using SA.Core.Enums;
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var user = await _userService.Login(_mapper.Map<LoginDto, User>(dto));

            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.RoleId.ToString()),
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            await HttpContext.SignInAsync(userPrincipal);

            if (user.RoleId == (int)DbEnums.Roles.Student)
            {
                return RedirectToAction("Index", "Students");
            }
            else if (user.RoleId == (int)DbEnums.Roles.Professor)
            {
                return RedirectToAction("Index", "Professors");

            }
            else
            {
                return RedirectToAction("Index", "Admins");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult NotFound()
        {
            return View();
        }

    }
}
