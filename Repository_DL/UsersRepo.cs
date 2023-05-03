using Repository_DL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_DL
{
    public class UsersRepo
    {
        

        public List<UsersTbl> GetAll()
        {
            using(BarterDbContext ctx=new BarterDbContext())
            {
                return ctx.UsersTbls.ToList();
            }
        }
        public void AddNew(UsersTbl user)
        {
            using BarterDbContext ctx = new BarterDbContext() ;
            ctx.UsersTbls.Add(user);
            ctx.SaveChanges();
        }
    }
}
