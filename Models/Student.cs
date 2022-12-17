using System;
using System.Collections.Generic;

namespace platzi_school.Models
{
    public class Student: SchoolBaseObject
    {
        // Referencia al modelo padre School
        public string? GradeId { get; set; }
        public Grade? Grade { get; set; }
        
        // Referencia al modelo hijo Asignatura
        public List<Assessment>? Assessments { get; set; }
    }
}