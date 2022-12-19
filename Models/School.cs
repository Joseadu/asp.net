using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace platzi_school.Models
{
    public class School:SchoolBaseObject
    {
        [Required]
        [Range(4, 4)]
        public int AñoDeCreación { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Pais { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Ciudad { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Dirección { get; set; }

        // Referencia a la interfaz TiposEscuela
        public TiposEscuela TipoEscuela { get; set; }

        // Referencia al modelo hijo Grade
        public List<Grade>? Grades { get; set; }

        public School(string nombre, int año) => (Name, AñoDeCreación) = (nombre, año);

        public School(string nombre, int año, 
                       TiposEscuela tipo, 
                       string pais = "", string ciudad = "") : base()
        {
            (Name, AñoDeCreación) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }
        public School()
        {
            
        }

        public override string ToString()
        {
            return $"Nombre: \"{Name}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }
    }
}
