using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionGestionEMS.Models
{
    public class Matriculas
    {
        [Key]
        public int IdMatricula { get; set; }

        [Display(Name = "Curso")]
        public int codCurso { get; set; }
        public virtual Cursos Curso { get; set; }

        [Display(Name = "Grupo de Clase")]
        public int codGrupoClase { get; set; }
        public virtual GrupoClases GrupoClase { get; set; }

        [Display(Name = "Alumno")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}