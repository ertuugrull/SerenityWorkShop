using Business.Abstract;
using Entities.Concrete;
using SerenityUI.Models;
using System;
using System.Collections.Generic;
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
        public ActionResult userAdd(User user)
        {
            _userService.Add(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult userEdit(int Id)
        {
            var model = new UserListViewModel();
            model.User = _userService.GetUser(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult userEdit(User user)
        {

            return RedirectToAction("");
        }
        public ActionResult userDelete()
        {
            

            return View();
        }
    }
}