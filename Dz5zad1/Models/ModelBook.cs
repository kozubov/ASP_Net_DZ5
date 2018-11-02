using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dz5zad1.Models
{
    public class ModelBook
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле имя")]
        [Display(Name = "Название книги: ")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Заполните поле дата")]
        [Display(Name = "Дата публикации: ")]
        [DataType(DataType.Date)]
        public string PublishDate { get; set; }
        [Required(ErrorMessage = "Заполните поле страницы")]
        [RegularExpression(@"\-?\d+(\d{0,})?", ErrorMessage = "Некоректный ввод страниц")]
        [Display(Name = "Количество страниц: ")]
        [DataType(DataType.Text)]
        public string PageCount { get; set; }
        [Required(ErrorMessage = "Заполните поле ISBN")]
        [Display(Name = "ISBN: ")]
        [DataType(DataType.Text)]
        public string ISBN { get; set; }
        public string RadioCeck { get; set; }
        public IList<string> SelectedCeck { get; set; } = new List<string>();
    }
}