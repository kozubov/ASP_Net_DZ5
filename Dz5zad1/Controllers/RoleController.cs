using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dz5zad1.Conteiner;
using Dz5zad1.Models;

namespace Dz5zad1.Controllers
{
    public class RoleController : Controller
    {
        Singelton singelton=Singelton.Instens;
        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {
            Role role=new Role();
            return View(role);
        }

        [HttpPost]
        public ActionResult Index(Role role)
        {
            if (ModelState.IsValid)
            {
                singelton.Add_Role(role);
                ViewBag.Roles = singelton.GetRole;
                return RedirectToAction("Show_Table");
            }
            else
            {
               return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.Roles = singelton.GetRole;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            var Find_role = singelton.GetRole.Find(role => role.Id == id);
            if (Find_role == null)
            {
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            return View(Find_role);
        }

        [HttpPost]
        public ActionResult Edit(Role rol)
        {
            if (ModelState.IsValid)
            {
                var Find_role = singelton.GetRole.Find(role => role.Id == rol.Id);
                Find_role.Name = rol.Name;
                foreach (var VARIABLE in singelton.GetUsers)
                {
                    VARIABLE.Rename_Role(Find_role);
                }
                ViewBag.Roles = singelton.GetRole;
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
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            var Find_role = singelton.GetRole.Find(role => role.Id == id);
            if (Find_role == null)
            {
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            singelton.GetRole.Remove(Find_role);
            foreach (var VAR in singelton.GetUsers)
            {
                VAR.Delete_Role();
            }
            ViewBag.Roles = singelton.GetRole;
            return View("Show_Table");
        }

        public ActionResult Learn_More(int? id)
        {
            if (id == null)
            {
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            var Find_role = singelton.GetRole.Find(role => role.Id == id);
            if (Find_role == null)
            {
                ViewBag.Roles = singelton.GetRole;
                return View("Show_Table");
            }

            return View(Find_role);
        }
    }
}