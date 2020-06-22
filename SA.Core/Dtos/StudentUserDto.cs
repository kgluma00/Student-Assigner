using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Dtos
{
    public class StudentUserDto
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryOfBirth { get; set; }
        public double AverageGrade { get; set; }
        public byte StudyLevel { get; set; }
        public string Comment { get; set; }
        public double Points { get; set; }
        public byte NmbrOfRptYears { get; set; }
    }
}
