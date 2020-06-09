using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SA.Core.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte CourseId { get; set; }
        public float AverageGrade { get; set; }
        public byte NmbrOfRptYears { get; set; }
        public double Points { get; set; }
        public string Comment { get; set; }
        public bool IsAssigned { get; set; }
        public byte StudyLevel { get; set; }
    }
}
