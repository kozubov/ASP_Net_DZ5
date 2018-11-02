using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dz5zad1.Models
{
    public class ModelUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле Имя")]
        [Display(Name = "Имя: ")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Заполните поле Фамилия")]
        [Display(Name = "Фамилия: ")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Display(Name = "Логин: ")]
        [Required(ErrorMessage = "Заполните поле Логин")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле логин должно быть от 5 до 20 символов")]
        [DataType(DataType.Text)]
        public string Login { get; set; }
        [Display(Name = "Пароль: ")]
        [Required(ErrorMessage = "Заполните поле Пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Поле пароль должно быть от 5 до 30 символов")]
        [DataType(DataType.Password)]
        public string Passvord { get; set; }
        [Display(Name = "Почта: ")]
        [Required(ErrorMessage = "Заполните поле Почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Не коректная почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Телефон: ")]
        [Required(ErrorMessage = "Заполните поле Тулефон")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Некоректный ввод телефона")]
        public string Phone
        {
            get { return str; }
            set { str = value; }
        }
        [Display(Name = "Роль: ")]
        public string role { get; set; }
        private string str ="+380";
        public ModelUser() { }

        public ModelUser(int id, string firstName, string lastName, string login, string passvord, string email,
            string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Passvord = passvord;
            Email = email;
            Phone = phone;
        }
    }
}