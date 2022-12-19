using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace platzi_school.Models
{
    public class Grade:SchoolBaseObject
    {
        [Required(ErrorMessage ="Requerido. Máximo 40 caracteres")]
        [StringLength(40)]
        public override string? Name { get; set; }
        // Referencia al modelo padre School
        public string? SchoolId { get; set; }
        public School? School { get; set; }

        // Referencia los modelos hijo Subject y Student
        public List<Subject>? Subjects{ get; set; }
        public List<Student>? Alumnos{ get; set; }

        [Required(ErrorMessage ="Requerido. Longitud máxima 50 caracteres")]
        [MaxLength(50)]
        public string? Dirección { get; set; }
        
        public TiposJornada Jornada { get; set; }

    }
}