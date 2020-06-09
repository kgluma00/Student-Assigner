using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SA.Core.Dtos;
using SA.Core.Interfaces;

namespace SA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public ISaRepository _context { get; }

        public UsersController(ISaRepository context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> SaveUser(UserDto dto)
        {
            await _context.Add(dto);
            return Ok();
        }

    }
}
