using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz5zad1.Conteiner;
using Dz5zad1.Models;

namespace Dz5zad1.Controllers
{
    public class PublisherController : Controller
    {
        Singelton sengelton=Singelton.Instens;
        // GET: Publisher
        [HttpGet]
        public ActionResult Index()
        {
            Publisher pub=new Publisher();
            return View(pub);
        }

        [HttpPost]
        public ActionResult Index(Publisher pub)
        {
            if (ModelState.IsValid)
            {
                sengelton.Add_Publisher(pub);
                return RedirectToAction("Show_Table");
            }
            else
            {
               
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Publisher = sengelton.GetPublishers;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Publisher = sengelton.GetPublishers;
                return View("Show_Table");
            }
            var Find_Publisher = sengelton.GetPublishers.Find(Publisher => Publisher.Id == id);
            if (Find_Publisher == null)
            {
                ViewBag.Publisher = sengelton.GetPublishers;
                return View("Show_Table");
            }
            return View(Find_Publisher);
        }

        [HttpPost]
        public ActionResult Edit(Publisher publisher, int id)
        {
            if (ModelState.IsValid)
            {
                var Find_Publisher = sengelton.GetPublishers.Find(Publisher => Publisher.Id == id);
                Find_Publisher.Name = publisher.Name;
                ViewBag.Publisher = sengelton.GetPublishers;
                Rename_Book_Publisher(Find_Publisher);
                return RedirectToAction("Show_Table");
            }
            else
            {
                return View();
            }
        }

        private void Rename_Book_Publisher(Publisher findPublisher)
        {
            foreach (var VARIABLE in sengelton.GetBooks)
            {
                VARIABLE.Rename_Publisher(findPublisher);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Publisher = sengelton.GetPublishers;
                return View("Show_Table");
            }
            var Find_Publisher = sengelton.GetPublishers.Find(Publisher => Publisher.Id == id);
            sengelton.GetPublishers.Remove(Find_Publisher);
            ViewBag.Publisher = sengelton.GetPublishers;
            Delete_Book_Publisher(Find_Publisher);
            return View("Show_Table");
        }

        private void Delete_Book_Publisher(Publisher findPublisher)
        {
            foreach (var VARIABLE in sengelton.GetBooks)
            {
                VARIABLE.Delete_Publisher(findPublisher);
            }
        }

        public ActionResult Learn_More(int? id)
        {
            if (id == null)
            {
                return View("Show_Table");
            }
            var Find_Publisher = sengelton.GetPublishers.Find(Publisher => Publisher.Id == id);
            if (Find_Publisher == null)
            {
                ViewBag.Publisher = sengelton.GetPublishers;
                return View("Show_Table");
            }
            return View(Find_Publisher);
        }
    }
}