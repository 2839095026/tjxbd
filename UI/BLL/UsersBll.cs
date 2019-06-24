using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
using System.Data;

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

        public users Login(users u)
        {
            return dao.Login(u);
        }
        public DataTable FindAllliangbiao(string fileName)
        {
            return dao.FindAllliangbiao(fileName);
        }
        public List<users> SelectWhere(int id)
        {
            return dao.SelectWhere(t=>t.u_id==id);
        }
        public List<users> FenYe(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<int>(pageIndex,pageSize,out Count,e=>e.u_id !=0, e => e.u_id);
        }

    }
}
