using System;
using System.ComponentModel.DataAnnotations;

namespace platzi_school.Models
{
    public abstract class SchoolBaseObject
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; }

        public SchoolBaseObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{Name},{Id}";
        }
    }
}