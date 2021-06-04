﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        void Add(User user);
        void Delete(int userId);
        void Update(User user);
        User GetUser(int userId);
    }
}