using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dz5zad1.Models
{
    public class Publisher
    {
        [ScaffoldColumn(false)]
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название издательства: ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        public Publisher() { }
    }
}