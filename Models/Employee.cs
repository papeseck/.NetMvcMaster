using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MvcGlAtelier2023.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }
        [MaxLength(80), Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [ Required(ErrorMessage = "*")]
        public int Age { get; set; }
        [MaxLength(80), Required(ErrorMessage = "*")]
        public string State { get; set; }
        [MaxLength(80), Required(ErrorMessage = "*")]
        public string Country
        {
            get; set;
        }
    }
}