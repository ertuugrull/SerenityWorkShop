using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Business
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserDal, EfUserDal>();
            container.RegisterType<IUserService, UserManager>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}