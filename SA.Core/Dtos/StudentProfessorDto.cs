using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Dtos
{
    public class StudentProfessorDto
    {
        public StudentUserDto StudentUserDto { get; set; }
        public List<ProfessorBasicInfoDto> ProfessorBasicInfoDto { get; set; }
        public ProfessorBasicInfoDto AssignedProfessorBasicInfoDto { get; set; }
    }
}
