using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
namespace BLL
{
    //IBLL.IConfigFileFirstKindBll bll = IocContainer.IocCreate.CreateBll<IConfigFileFirstKindBll>("ConfigFileFirstKindBll");

    public class ConfigFileFirstKindBll : IConfigFileFirstKindBll
    {
        IConfigFileFirstKindDao<config_file_first_kind> dao = IocCreate.CreateDao<IConfigFileFirstKindDao<config_file_first_kind>>("ConfigFileFirstKindDao");

        public int Add(config_file_first_kind t)
        {
            return dao.Add(t);
        }

        public int Change(config_file_first_kind t)
        {
            return dao.Change(t);
        }

        public int Del(config_file_first_kind t)
        {
            return dao.Del(t);
        }

       
        public List<config_file_first_kind> FindAll()
        {
            return dao.FindAll();
        }
    }
}
