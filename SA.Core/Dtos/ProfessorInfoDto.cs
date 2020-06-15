using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.MVC.Models
{
    public class ProfessorInfoDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AreaOfInterestOne { get; set; }
        public string AreaOfInterestTwo { get; set; }
        public string AreaOfInterestThree { get; set; }
    }
}
