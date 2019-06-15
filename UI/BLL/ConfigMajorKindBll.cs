using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using IBLL;
using Entity;
using IocContainer;
namespace BLL
{
    //IBLL.IConfigMajorKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigMajorKindBll>("ConfigMajorKindBll");

    public class ConfigMajorKindBll : IConfigMajorKindBll
    {
        IConfigMajorKindDao<config_major_kind> dao = IocCreate.CreateDao<IConfigMajorKindDao<config_major_kind>>("ConfigMajorKindDao");

        public int Add(config_major_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_major_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_major_kind t)
        {
            return dao.Del(t);
        }

        public List<config_major_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
