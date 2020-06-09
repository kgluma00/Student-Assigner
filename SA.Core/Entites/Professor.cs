using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SA.Core.Entites
{
    public class Professor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte CourseId { get; set; }
        public float MaxPoints { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string AreaOfInterestOne { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string AreaOfInterestTwo { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string AreaOfInterestThree { get; set; }
    }
}
