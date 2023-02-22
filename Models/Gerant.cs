using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGlAtelier2023.Models
{
    public class Gerant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGerant { get; set; }
        [Display(Name ="Matricule"), MaxLength(80, ErrorMessage = "Taille maximale 20 "), Required(ErrorMessage = ("*"))]
        public string Matricule { get; set; }
    }
}