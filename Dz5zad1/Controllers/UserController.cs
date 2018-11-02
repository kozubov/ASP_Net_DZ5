using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using  Dz5zad1.Models;
using Dz5zad1.Conteiner;

namespace Dz5zad1.Controllers
{

    public class UserController : Controller
    {
        private Singelton singelton = Singelton.Instens;
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            ModelUser user = new ModelUser();
            Show_ListItem();
            return View(user);
        }

        private void Show_ListItem()
        {
            List<SelectListItem> list=new List<SelectListItem>();
            foreach (var VARIABLE in singelton.GetRole)
            {
                list.Add(new SelectListItem {Text = $"{VARIABLE.Name}",Value = $"{VARIABLE.Id}"});
            }

            ViewBag.List = list;
        }

        [HttpPost]
        public ActionResult Index(ModelUser use)
        {
            if (ModelState.IsValid)
            {
                User user=new User(use.FirstName,use.LastName,use.Login,use.Passvord,use.Email,use.Phone);
                var find_rol = singelton.GetRole.Find(Role => Role.Id == Convert.ToInt32(use.role));
                user.Add_Rol(find_rol);
                singelton.Add_User(user);
                ViewBag.User = singelton.GetUsers;
                return RedirectToAction("Show_Table");
            }
            else
            {
                Show_ListItem();
                return View();
            }
        }

        public ActionResult Show_Table()
        {
            ViewBag.User = singelton.GetUsers;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            var Finf_user = singelton.GetUsers.Find(user => user.Id == id);
            if (Finf_user == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            Show_Edit_User_Role(Finf_user.Role?.Id??null);
            ModelUser User = new ModelUser(Finf_user.Id, Finf_user.FirstName, Finf_user.LastName, Finf_user.Login,
                Finf_user.Passvord, Finf_user.Email, Finf_user.Phone);
            return View(User);
        }

        [HttpPost]
        public ActionResult Edit(ModelUser model)
        {
            if (ModelState.IsValid)
            {
                var find_User = singelton.GetUsers.Find(user => user.Id == model.Id);
                find_User.Renam_User(model.FirstName, model.LastName, model.Login, model.Passvord, model.Email,
                    model.Phone);
                var find_Role = singelton.GetRole.Find(role => role.Id == Convert.ToInt32(model.role));
                find_User.Add_Rol(find_Role);
                ViewBag.User = singelton.GetUsers;
                return RedirectToAction("Show_Table");
            }
            else
            {
                Show_Edit_User_Role(model.Id);
                return View();
            }
        }
        private void Show_Edit_User_Role(int? id)
        {
            List<SelectListItem>list=new List<SelectListItem>();
            foreach (var role in singelton.GetRole)
            {
                if (id!=null)
                {
                    if (role.Id == id)
                    {
                        list.Add(new SelectListItem{Text = $"{role.Name}",Value = $"{role.Id}",Selected = true});
                    }
                    else
                    {
                        list.Add(new SelectListItem { Text = $"{role.Name}", Value = $"{role.Id}", Selected = false });
                    }
                }
                else
                {
                    list.Add(new SelectListItem { Text = $"{role.Name}", Value = $"{role.Id}", Selected = false });
                }
            }

            ViewBag.List = list;
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            var Finf_user = singelton.GetUsers.Find(user => user.Id == id);
            if (Finf_user == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            singelton.GetUsers.Remove(Finf_user);
            ViewBag.User = singelton.GetUsers;
            return View("Show_Table");
        }

        public ActionResult Learn_More(int? id)
        {
            if (id == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            var Finf_user = singelton.GetUsers.Find(user => user.Id == id);
            if (Finf_user == null)
            {
                ViewBag.User = singelton.GetUsers;
                return View("Show_Table");
            }

            return View(Finf_user);
        }
    }
}