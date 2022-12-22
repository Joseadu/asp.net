using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace platzi_school.Models
{
    public class School:SchoolBaseObject
    {
        [Required]
        [Range(4, 4)]
        public int CreationDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Country { get; set; }
        [Required]
        [MaxLength(20)]
        public string? City { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Dirección { get; set; }

        // Referencia a la interfaz TiposEscuela
        public TypeSchool TypeSchool { get; set; }

        // Referencia al modelo hijo Grade
        public List<Grade>? Grades { get; set; }

        public School(string nanme, int year) => (Name, CreationDate) = (nanme, year);

        public School(string name, int year, 
                       TypeSchool tipo, 
                       string country = "", string city = "") : base()
        {
            (Name, CreationDate) = (name, year);
            Country = country;
            City = city;
        }
        public School()
        {
            
        }

        public override string ToString()
        {
            return $"Nombre: \"{Name}\", Tipo: {TypeSchool} {System.Environment.NewLine} Pais: {Country}, Ciudad:{City}";
        }
    }
}
