using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte CourseId { get; set; }
        public float MaxPoints { get; set; }
        public string AreaOfInterestOne { get; set; }
        public string AreaOfInterestTwo { get; set; }
        public string AreaOfInterestThree { get; set; }
    }
}
