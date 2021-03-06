﻿using SA.Core.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA.MVC.Models
{
    public class StudentInfoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CourseName { get; set; }
        public double AverageGrade { get; set; }
        public byte NmbrOfRptYears { get; set; }
        public double Points { get; set; }
        public string Comment { get; set; }
        public byte StudyLevel { get; set; }
        public int AssignedProfessor { get; set; }
        public List<ProfessorDto> ProfessorDtos { get; set; }
    }
}
