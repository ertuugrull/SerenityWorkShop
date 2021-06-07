using Business.Abstract;
using Entities.Concrete;
using SerenityUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerenityUI.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var model = new UserListViewModel();
            model.Users = _userService.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public ActionResult userAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userAdd(User user, HttpPostedFileBase FilePhoto)
        {
            if (ModelState.IsValid)
            {
                if (FilePhoto != null && FilePhoto.ContentType=="image/jpeg")
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"),user.Name.ToLower() + "_" + user.Surname.ToLower() + ".jpeg");
                    user.FilePhoto = user.Name.ToLower() + "_" + user.Surname.ToLower() + ".jpeg";
                    FilePhoto.SaveAs(path);
                }
                _userService.Add(user);
                return RedirectToAction("Index");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult userEdit(int Id)
        {
            var model = _userService.GetUser(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult userEdit(User user, HttpPostedFileBase FilePhoto)
        {
            if (ModelState.IsValid)
            {
                if (FilePhoto != null && FilePhoto.ContentType == "image/jpeg")
                {
                    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), user.Name.ToLower() + "_" + user.Surname.ToLower() + ".jpeg");
                    user.FilePhoto = user.Name.ToLower() + "_" + user.Surname.ToLower() + ".jpeg";
                    FilePhoto.SaveAs(path);
                }
                _userService.Update(user);
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult userDelete(int id)
        {
            _userService.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}