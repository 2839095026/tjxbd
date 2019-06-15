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
    //IBLL.IConfigFileThirdKindBll bll = IocContainer.IocCreate.CreateBll<IBLL.IConfigFileThirdKindBll>("ConfigFileFirstKindBll");

    public class ConfigFileThirdKindBll : IConfigFileThirdKindBll
    {
        IConfigFileThirdKindDao<config_file_third_kind> dao = IocCreate.CreateDao<IConfigFileThirdKindDao<config_file_third_kind>>("ConfigFileThirdKindDao");

        public int Add(config_file_third_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_file_third_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_file_third_kind t)
        {
            return dao.Del(t);
        }

        public List<config_file_third_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
