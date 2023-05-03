using Repository_DL.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_BL
{
    public class UsersServices
    {


        public List<Repository_DL.DBModels.UsersTbl> GetAll()
        {
            return new Repository_DL.UsersRepo().GetAll();
        }
        public void AddNew(UsersTbl user)
        {
            new Repository_DL.UsersRepo().AddNew(user);
        }
    }
}
