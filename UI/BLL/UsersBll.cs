using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;

namespace BLL
{
    //IBLL.IUsersBll bll = IocContainer.IocCreate.CreateBll<IBLL.IUsersBll>("UsersBll");
    public class UsersBll : IUsersBll
    {
        IUsersDao<users> dao = IocCreate.CreateDao<IUsersDao<users>>("UsersDao");

        public int Add(users t)
        {
            return dao.Add(t);
        }

        public int Change(users t)
        {
            return dao.Change(t);
        }

        public int Del(users t)
        {
            return dao.Del(t);
        }

        public List<users> FindAll()
        {
            return dao.FindAll();
        }
    }
}
