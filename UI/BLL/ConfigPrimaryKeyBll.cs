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
    //IBLL.IConfigPrimaryKeyBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigPrimaryKeyBll>("ConfigPrimaryKeyBll");

    public class ConfigPrimaryKeyBll : IConfigPrimaryKeyBll
    {
        IConfigPrimaryKeyDao<config_primary_key> dao = IocCreate.CreateDao<IConfigPrimaryKeyDao<config_primary_key>>("ConfigPrimaryKeyDao");

        public int Add(config_primary_key t)
        {
            return dao.Add(t);
        }

        public int Change(config_primary_key t)
        {
            return dao.Change(t);
        }

        public int Del(config_primary_key t)
        {
            return dao.Del(t);
        }

        public List<config_primary_key> FindAll()
        {
            return dao.FindAll();
        }
    }
}
