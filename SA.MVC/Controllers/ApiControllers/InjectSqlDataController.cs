using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Dtos;
using SA.Core.Entites;
using SA.Core.Interfaces;

namespace SA.MVC.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectSqlDataController : ControllerBase
    {
        public ISaRepository _context { get; }
        private readonly IMapper _mapper;

        public InjectSqlDataController(ISaRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> SaveUser(List<UserDto> dto)
        {
            await _context.AddAsyncEntity(_mapper.Map<List<UserDto>, List<User>>(dto));
            return Ok();
        }

        [HttpPost]
        [Route("student")]
        public async Task<ActionResult> SaveStudent(List<StudentDto> dto)
        {
            await _context.AddAsyncEntity(_mapper.Map<List<StudentDto>, List<Student>>(dto));
            return Ok();
        }

        [HttpPost]
        [Route("professor")]
        public async Task<ActionResult> SaveProfessor(List<ProfessorDto> dto)
        {
            await _context.AddAsyncEntity(_mapper.Map<List<ProfessorDto>, List<Professor>>(dto));
            return Ok();
        }
    }
}
