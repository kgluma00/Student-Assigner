using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SA.Core.Entites
{
    public class Role
    {
        public byte Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string RoleName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
