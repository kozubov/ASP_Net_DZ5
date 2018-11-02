using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

namespace Dz5zad1.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Display(Name = "Имя автора: ")]
        public string Name { get; set; }
        [Display(Name = "Дата рождения: ")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Дата смерти: ")]
        public DateTime DateOfDeath { get; set; }

        public Author(string name,string dateOfBirth,string dateOfDeath)
        {
            Name = name;
            DateOfBirth = dateOfBirth.AsDateTime();
            DateOfDeath = dateOfDeath.AsDateTime();
        }

        public void Rename_Author(string name, string dateOfBirth, string dateOfDeath)
        {
            Name = name;
            DateOfBirth = dateOfBirth.AsDateTime();
            DateOfDeath = dateOfDeath.AsDateTime();
        }
    }
}