using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using IBLL;
using IocContainer;
using System.Data;

namespace BLL
{
    //IBLL.IPermissionsBll bll = IocContainer.IocCreate.CreateBll<IBLL.IPermissionsBll>("PermissionsBll");

    public class PermissionsBll : IPermissionsBll
    {
        IPermissionsDao<Permissions> dao = IocCreate.CreateDao<IPermissionsDao<Permissions>>("PermissionsDao");

        public int Add(Permissions t)
        {
            return dao.Add(t);
        }

        public int Change(Permissions t)
        {
            return dao.Change(t);
        }

        public int Del(Permissions t)
        {
            return dao.Del(t);
        }

        public List<Permissions> FindAll()
        {
            return dao.FindAll();
        }
        public DataTable PermissionsAll(string fileName, int useId, int qxid) {
            return dao.PermissionsAll(fileName,useId,qxid);
        }

    }
}
