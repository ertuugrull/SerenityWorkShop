using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(int userId)
        {
            _userDal.Delete(_userDal.Get(x=>x.Id==userId));
        }

        public List<User> GetAllUsers()
        {
            return _userDal.GetList();
        }

        public User GetUser(int userId)
        {
            return _userDal.Get(x=>x.Id==userId);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
