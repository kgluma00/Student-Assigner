using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SA.Core.Entites
{
    public class User
    {
        public int Id { get; set; }
        public byte RoleId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DoB { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string CountryOfBirth { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
