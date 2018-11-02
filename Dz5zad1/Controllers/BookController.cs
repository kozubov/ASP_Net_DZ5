using Dz5zad1.Conteiner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Dz5zad1.Models;

namespace Dz5zad1.Controllers
{
    public class BookController : Controller
    {
        Singelton singelton = Singelton.Instens;
        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            Show_RadioAndCeck();
            return View();
        }
        private void Show_RadioAndCeck()
        {
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> ceckBox = new List<SelectListItem>();
            if (singelton.GetPublishers.Count != 0)
            {
                foreach (var VARIABLE in singelton.GetPublishers)
                {
                    radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            if (singelton.GetAuthors.ToList().Count != 0)
            {
                foreach (var VARIABLE in singelton.GetAuthors)
                {
                    ceckBox.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                }
            }

            ViewBag.Radio = radio;
            ViewBag.Check = ceckBox;
        }

        [HttpPost]
        public ActionResult Index(ModelBook book)
        {
            if (ModelState.IsValid)
            {
                Book booksBook=new Book(book.Name,book.PublishDate,book.PageCount,book.ISBN);
                foreach (var VARIABLE in book.SelectedCeck)
                {
                    var find_Author = singelton.GetAuthors.Find(Author => Author.Id == Convert.ToInt32(VARIABLE));
                    booksBook.Add_Author(find_Author);
                }

                var find_Publisher =
                    singelton.GetPublishers.Find(Publisher => Publisher.Id == Convert.ToInt32(book.RadioCeck));
                booksBook.Add_BookPublicher(find_Publisher);
                singelton.Add_Book(booksBook);
                ViewBag.Books = singelton.GetBooks;
                return RedirectToAction("Show_Table");
            }
            else
            {
                Show_RadioAndCeck();
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Books = singelton.GetBooks;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }
            Book Find_book = singelton.GetBooks.Find(Book => Book.Id == id);
            if (Find_book == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }
            ShovEdit_RadioAndChec(Find_book);
            ModelBook model = new ModelBook()
            {
                ISBN = Find_book.ISBN,
                Name = Find_book.Name,
                PageCount = Find_book.PageCount.ToString(),
                PublishDate = Find_book.PublishDate.ToString("yyyy-MM-dd"),
                Id=Find_book.Id
            };
            return View(model);
        }

        private void ShovEdit_RadioAndChec(Book Find_book)
        {
            List<SelectListItem> radio = new List<SelectListItem>();
            List<SelectListItem> ceckBox = new List<SelectListItem>();
            
            if (singelton.GetPublishers.Count != 0)
            {
                foreach (var VARIABLE in singelton.GetPublishers)
                {
                    if (Find_book.publisher!=null)
                    {
                        if (Find_book.publisher.Id==VARIABLE.Id)
                        {
                            radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}",Selected = true});
                        }
                        else
                        {
                            radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                        }
                    }
                    else
                    {
                        radio.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                    }
                }
            }

            if (singelton.GetAuthors.ToList().Count != 0)
            {
                foreach (var VARIABLE in singelton.GetAuthors)
                {
                    if (Find_book.Authors.ToList().Count!=0)
                    {
                        int count = 0;
                        foreach (var VAR in Find_book.Authors)
                        {
                            if (VARIABLE.Id == VAR.Id)
                            {
                                ceckBox.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}",Selected = true});
                                count++;
                            }
                        }

                        if (count == 0)
                        {
                            ceckBox.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}", Selected = false });
                        }
                        
                    }
                    else
                    {
                        ceckBox.Add(new SelectListItem { Text = $"{VARIABLE.Name}", Value = $"{VARIABLE.Id}" });
                    }
                }
            }

            ViewBag.Radio = radio;
            ViewBag.Check = ceckBox;
        }

        [HttpPost]
        public ActionResult Edit(ModelBook book)
        {
            if (ModelState.IsValid)
            {
                var find_book = singelton.GetBooks.Find(Book => Book.Id == book.Id);
                find_book.Raname_Book(book.Name,book.PublishDate,book.PageCount,book.ISBN);
                Publisher find_Publischer = singelton.GetPublishers.Find(Pub => Pub.Id == Convert.ToInt32(book.RadioCeck));
                find_book.Add_BookPublicher(find_Publischer);
                find_book.Clear_Author();
                foreach (var VARIABLE in book.SelectedCeck)
                {
                    var find_Author = singelton.GetAuthors.Find(Author => Author.Id == Convert.ToInt32(VARIABLE));
                    find_book.Add_Author(find_Author);
                }
                ViewBag.Books = singelton.GetBooks;
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }

            var Find_book = singelton.GetBooks.Find(Book => Book.Id == id);
            if (Find_book == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }

            singelton.GetBooks.Remove(Find_book);
            ViewBag.Books = singelton.GetBooks;
            return View("Show_Table");
        }

        public ActionResult Learn_More(int? id)
        {
            if (id == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }

            var Find_book = singelton.GetBooks.Find(book => book.Id == id);
            if (Find_book == null)
            {
                ViewBag.Books = singelton.GetBooks;
                return View("Show_Table");
            }

            return View(Find_book);
        }
    }
}