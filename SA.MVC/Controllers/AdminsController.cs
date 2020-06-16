﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SA.Business.Interfaces;
using SA.Core.Dtos;
using SA.MVC.Models;

namespace SA.MVC.Controllers
{
    public class AdminsController : Controller
    {
        public IMapper _mapper { get; }
        private readonly IUserService _userService;

        public AdminsController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<CoursesDto>> GetAllCourses()
        {
            return await _userService.GetAllCourses();
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllStudentsByCoursesId(string courseId)
        {
            return await _userService.GetAllStudentsByCoursesId(byte.Parse(courseId));
        }
    }
}