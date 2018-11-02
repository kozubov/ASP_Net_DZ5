using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Dz5zad1.Conteiner;

namespace Dz5zad1.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Имя: ")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия: ")]
        public string LastName { get; set; }
        [Display(Name = "Логин: ")]
        public string Login { get; set; }
        [Display(Name = "Пароль: ")]
        public string Passvord { get; set; }
        [Display(Name = "Почта: ")]
        public string Email { get; set; }
        [Display(Name = "Телефон: ")]
        public string Phone { get; set; }
        [Display(Name = "Роль: ")]
        public Role Role { get; set; }

        public User(string firstName, string lastName, string login, string passvord, string email,
            string phone)
        {

            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Passvord = passvord;
            Email = email;
            Phone = phone;
        }

        public void Add_Rol(Role role)
        {
            Role = role;
        }
      

        public void Renam_User(string firstName, string lastName, string login, string passvord, string email,
            string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Passvord = passvord;
            Email = email;
            Phone = phone;
        }

        public void Rename_Role(Role rol)
        {
            if ((Role?.Id??0) == rol.Id)
            {
                Role.Name = rol.Name;
            }
        }

        public void Delete_Role()
        {
            var Find_role = Singelton.Instens.GetRole.Find(role => role.Id == (Role?.Id??0));
            if (Find_role == null)
            {
                Role = null;
            }
        }
    }
}