using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Dz5zad1.Models
{
    public class ModelAuthor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя: ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите дату рождения")]
        [Display(Name = "Дата рождения: ")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [Display(Name = "Дата смерти: ")]
        [DataType(DataType.Date)]
        public string DateOfDeath
        {
            get => str;
            set
            {
                if (value!="0001-01-01")
                {
                    str = value;
                }
                else
                {
                    str = null;
                }
            }
        }

        private string str;
    }
}