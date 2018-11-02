using Dz5zad1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz5zad1.Conteiner
{
    public class Singelton
    {
        private static Singelton _instens;
        public static Singelton Instens => _instens ?? (_instens = new Singelton());
        public Singelton() { }
        private List<Publisher> Publishers =new List<Publisher>();
        private List<Author> Authors=new List<Author>();
        private List<Book>Books=new List<Book>();
        private List<Role>Roles=new List<Role>();
        private List<User>Users=new List<User>();
        public List<Publisher> GetPublishers => Publishers;
        public List<Author> GetAuthors => Authors;
        public List<Book> GetBooks => Books;
        public List<Role> GetRole => Roles;
        public List<User> GetUsers => Users;

        public void Add_Publisher(Publisher item)
        {
            item.Id = (Publishers.LastOrDefault()?.Id ?? 0) + 1;
            Publishers.Add(item);
        }

        public void Add_Authors(Author item)
        {
            item.Id = (Authors.LastOrDefault()?.Id ?? 0) + 1;
            Authors.Add(item);
        }

        public void Add_Book(Book book)
        {
            book.Id = (Books.LastOrDefault()?.Id ?? 0) + 1;
            Books.Add(book);
        }

        public void Add_Role(Role role)
        {
            role.Id = (Roles.LastOrDefault()?.Id ?? 0) + 1;
            Roles.Add(role);
        }

        public void Add_User(User user)
        {
            user.Id = (Users.LastOrDefault()?.Id ?? 0) + 1;
            Users.Add(user);
        }
    }
}