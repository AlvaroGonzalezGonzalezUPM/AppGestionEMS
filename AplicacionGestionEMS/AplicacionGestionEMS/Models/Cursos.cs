using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionGestionEMS.Models
{
    public class Cursos
    {
        [Key]
        public int codCurso { get; set; }
        public string nombre { get; set; }
    }
}