using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dz5zad1.Models
{
    public class Role
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя роли: ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public Role() { }
    }
}