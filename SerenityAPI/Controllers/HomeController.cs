using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SerenityAPI.Controllers
{
    public class HomeController : ApiController
    {
        IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public List<User> Getall()
        {
            var users = _userService.GetAllUsers();
            return users;
        }
        [HttpGet]
        public User GetById(int id)
        {
            var users = _userService.GetUser(id);
            return users;
        }
        [HttpPost]
        public IHttpActionResult Add(User user)
        {
            _userService.Add(user);

            return (IHttpActionResult)user;
        }
        [HttpPost]
        public IHttpActionResult Update(User user)
        {
            _userService.Update(user);

            return (IHttpActionResult)user;
        }
        [HttpPost]
        public void Delete(int id)
        {
           _userService.Delete(id);
      
        }
    }
}
