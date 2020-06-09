using SA.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string CountryOfBirth { get; set; }
        public byte RoleId { get; set; }
    }
}
