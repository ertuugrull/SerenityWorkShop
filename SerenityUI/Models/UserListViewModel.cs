using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerenityUI.Models
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public User User { get; set; }
    }
}