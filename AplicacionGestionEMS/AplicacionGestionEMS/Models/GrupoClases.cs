using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionGestionEMS.Models
{
    public class GrupoClases
    {
        [Key]
        public int codGrupoClase { get; set; }
        public string nombre { get; set; }
    }
}