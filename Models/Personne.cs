using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGlAtelier2023.Models
{
    public class Personne
    {
        [Key]
        public int IdPers { get; set; }
        [Display(Name ="Nom") ,MaxLength(80 ,ErrorMessage ="Taille maximale 80 "),Required(ErrorMessage =("*"))]
        public string NomPers { get; set; }
        [Display(Name = "Prenom"), MaxLength(80, ErrorMessage = "Taille maximale 80 "), Required(ErrorMessage = ("*"))]
        public string PrenomPers { get; set; }
        [Display(Name = "Adresse"), MaxLength(150, ErrorMessage = "Taille maximale 150 "), Required(ErrorMessage = ("*"))]
        public string AdresPers { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), MaxLength(80, ErrorMessage = "Taille maximale 80 "), Required(ErrorMessage = ("*"))]
        public string EmailPers { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "telephone"), MaxLength(80, ErrorMessage = "Taille maximale 20 "), Required(ErrorMessage = ("*"))]
        public string telPers { get; set; }
    }
}