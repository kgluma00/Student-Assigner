using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Dtos
{
    public class ProfessorBasicInfoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AreaOfInterestOne { get; set; }
        public string AreaOfInterestTwo { get; set; }
        public string AreaOfInterestThree { get; set; }
    }
}
