using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Dz5zad1.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Имя книги: ")]
        public string Name { get; set; }
        [Display(Name = "Публикация: ")]
        public Publisher publisher { get; set; }
        [Display(Name = "Автор(ы): ")]
        public IEnumerable<Author> Authors { get; set; }
        [Display(Name = "Дата публикации: ")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Количество страниц: ")]
        public int PageCount { get; set; }
        [Display(Name = "ISBN: ")]
        public string ISBN { get; set; }

        public Book(string name, string date, string pageCount, string isbn)
        {
            Authors = new List<Author>();
            Name = name;
            PublishDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }

        public void Raname_Book(string name, string date, string pageCount, string isbn)
        {
            Name = name;
            PublishDate = date.AsDateTime();
            PageCount = Convert.ToInt32(pageCount);
            ISBN = isbn;
        }
        public void Add_BookPublicher(Publisher publisher)
        {
            this.publisher = publisher;
        }
        public IEnumerable<Author> Get_BookAuthor => Authors;

        public void Add_Author(Author author)
        {
            Authors = Authors.Add(author);
        }

        public void Clear_Author()
        {
            Authors = Authors.Clear();
        }

        public void Rename_Author(Author author)
        {
            Authors = Authors.Rename(author);
        }

        public void Delete_Author(Author author)
        {
            Authors = Authors.Delete(author);
        }

        public void Delete_Publisher(Publisher pub)
        {
            if (publisher!=null)
            {
                if (publisher.Id == pub.Id)
                {
                    publisher = null;
                }
            }
        }

        public void Rename_Publisher(Publisher pub)
        {
            if (publisher!=null)
            {
                if (publisher.Id == pub.Id)
                {
                    publisher = pub;
                }
            }
        }
    }
}