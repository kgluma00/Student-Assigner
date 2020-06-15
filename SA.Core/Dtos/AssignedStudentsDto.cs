using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SA.Core.Dtos
{
    public class AssignedStudetnsDto
    {
        [Display(Name = "Ime")]
        public string StudentFirstName { get; set; }
        [Display(Name = "Prezime")]
        public string StudentLastName { get; set; }
        [Display(Name = "Smjer")]
        public int CourseId { get; set; }
        [Display(Name = "Prosjek")]
        public float AverageGrade { get; set; }
        [Display(Name = "Diplomski / Završni")]
        public int StudyLevel { get; set; }
        [Display(Name = "Komentar")]
        public string Comment { get; set; }
    }
}