using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SA.Core.Entites
{
    public class Course
    {
        public byte Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string CourseName { get; set; }
    }
}
