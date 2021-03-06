using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class SerenityContext : DbContext
    {
 
    public SerenityContext() : base("name=SerenityContext")
        {
            var ensureDLLIsCopied =
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<User> Users { get; set; }
    }
}
