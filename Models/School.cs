using System;
using System.Collections.Generic;

namespace platzi_school.Models
{
    public class School:SchoolBaseObject
    {
        public int AñoDeCreación { get; set; }

        public string? Pais { get; set; }
        public string? Ciudad { get; set; }

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
