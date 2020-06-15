using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Enums
{
    public class DbEnums
    {
        public enum Roles
        {
            Student = 1,
            Professor = 2,
            Admin = 3
        }

        public enum Courses
        {
            Računarstvo = 1,
            Strojarstvo = 2,
            Brodogradnja = 3,
            Elektrotehnika = 4
        }

        public enum StudyLevel
        {
            Završni = 1,
            Diplomski = 2
        }
    }
}
