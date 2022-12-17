using System;
using System.Collections.Generic;

namespace platzi_school.Models
{
    public class Grade:SchoolBaseObject
    {
        // Referencia al modelo padre School
        public string? SchoolId { get; set; }
        public School? School { get; set; }

        // Referencia los modelos hijo Subject y Student
        public List<Subject>? Subjects{ get; set; }
        public List<Student>? Alumnos{ get; set; }

        public string? Dirección { get; set; }
        public TiposJornada Jornada { get; set; }

    }
}