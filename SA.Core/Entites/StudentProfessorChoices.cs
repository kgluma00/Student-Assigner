using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Core.Entites
{
    public class StudentProfessorChoices
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProfessorId { get; set; }
        public byte Factor { get; set; }
    }
}
