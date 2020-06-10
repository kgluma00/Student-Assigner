using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA.MVC.Models
{
    public class UserHomeDto
    {
        public int Id { get; set; }
        public byte RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
