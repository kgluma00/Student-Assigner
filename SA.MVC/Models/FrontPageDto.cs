using SA.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.MVC.Models
{
    public class FrontPageDto
    {
        public UserHomeDto UserHomeDto { get; set; }
        public List<ProfessorBasicInfoDto> ProfessorBasicInfoDtos { get; set; }
    }
}
