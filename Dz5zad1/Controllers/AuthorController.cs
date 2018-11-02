using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz5zad1.Models;
using  Dz5zad1.Conteiner;

namespace Dz5zad1.Controllers
{
    public class AuthorController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: Author
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ModelAuthor authr)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author(authr.Name,authr.DateOfBirth,authr.DateOfDeath);
                singelton.Add_Authors(author);
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Autors = singelton.GetAuthors;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            var Find_Author = singelton.GetAuthors.Find(Author => Author.Id == id);
            if (Find_Author == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            ModelAuthor author = new ModelAuthor()
            {
                DateOfBirth = Find_Author.DateOfBirth.ToString("yyyy-MM-dd"),
                DateOfDeath = Find_Author.DateOfDeath.ToString("yyyy-MM-dd"),
                Name = Find_Author.Name,
                Id=Find_Author.Id
            };
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(ModelAuthor author)
        {
            if (ModelState.IsValid)
            {
                var Find_Author = singelton.GetAuthors.Find(Author => Author.Id == author.Id);
                Find_Author.Rename_Author(author.Name,author.DateOfBirth,author.DateOfDeath);
                ViewBag.Autors = singelton.GetAuthors;
                Rename_IEnum_Author(Find_Author);
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        private void Rename_IEnum_Author(Author author)
        {
            foreach (Book VARIABLE in singelton.GetBooks)
            {
                VARIABLE.Rename_Author(author);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            var Find_Author = singelton.GetAuthors.Find(Author => Author.Id == id);
            if (Find_Author == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            singelton.GetAuthors.Remove(Find_Author);
            ViewBag.Autors = singelton.GetAuthors;
            Delete_IEnum_Author(Find_Author);
            return View("Show_Table");
        }

        private void Delete_IEnum_Author(Author findAuthor)
        {
            foreach (var VARIABLE in singelton.GetBooks)
            {
                VARIABLE.Delete_Author(findAuthor);
            }
        }

        public ActionResult Learn_More(int? id)
        {
            if (id == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            var Find_Author = singelton.GetAuthors.Find(Author => Author.Id == id);
            if (Find_Author == null)
            {
                ViewBag.Autors = singelton.GetAuthors;
                return View("Show_Table");
            }
            return View(Find_Author);
        }
    }
}