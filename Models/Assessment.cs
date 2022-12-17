using System;

namespace platzi_school.Models
{
    public class Assessment:SchoolBaseObject
    {
        // Referencia al modelo padre Student
        public string? StudentId { get; set; }
        public Student? Student { get; set; }

        // Referencia al modelo padre Subject
        public string? SubjectId { get; set; }
        public Subject? Subject  { get; set; }

        public float Nota { get; set; }

        public override string ToString()
        {
            return $"{Nota}, {Student?.Name}, {Subject?.Name}";
        }
    }
}