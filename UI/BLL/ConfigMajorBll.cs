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
    //IBLL.IConfigMajorBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorBll>("ConfigMajorBll");

    public class ConfigMajorBll : IConfigMajorBll
    {
       IConfigMajorDao<config_major> dao = IocCreate.CreateDao<IConfigMajorDao<config_major>>("ConfigMajorDao");

        public int Add(config_major t)
        {
            return dao.Add(t);
        }

        public int Change(config_major t)
        {
            return dao.Change(t);
        }

        public int Del(config_major t)
        {
            return dao.Del(t);
        }

        public List<config_major> FindAll()
        {
            return dao.FindAll();
        }
    }
}
