using System;

namespace platzi_school.Models
{
    public class Subject:SchoolBaseObject
    {
        // Referencia a los modelos padre School y Grade
        public string? SchoolId { get; set; }
        public School? School { get; set; }


        public string? GradeId { get; set; }
        public Grade? Grade { get; set; }

        public List<Assessment>? Assessment { get; set; }
    }
}