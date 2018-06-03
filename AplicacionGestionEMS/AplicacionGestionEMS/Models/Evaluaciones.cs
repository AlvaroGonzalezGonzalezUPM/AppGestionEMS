using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionGestionEMS.Models
{
    public class Evaluaciones
    {
        [Key]
        public int EvaluacionId { get; set; }

        [Display(Name = "Alumno")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public bool evalContinua { get; set; }

        public float nota_P1 { get; set; }
        public float nota_P2 { get; set; }
        public float nota_P3 { get; set; }
        public float nota_P4 { get; set; }

        public float nota_Practica { get; set; }

        [Display(Name = "Curso")]
        public int codCurso { get; set; }
        public virtual Cursos Curso { get; set; }
    }
}