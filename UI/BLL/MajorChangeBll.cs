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
    //IBLL.IHumanFileDigBll bll = IocContainer.IocCreate.CreateBll<IBLL.IHumanFileDigBll>("HumanFileDigBll");

    public class MajorChangeBll : IMajorChangeBll
    {
        IMajorChangeDao<major_change> dao = IocCreate.CreateDao<IMajorChangeDao<major_change>>("MajorChangeDao");

        public int Add(major_change t)
        {
            return dao.Add(t);
        }

        public int Change(major_change t)
        {
            return dao.Change(t);
        }

        public int Del(major_change t)
        {
            return dao.Del(t);
        }

        public List<major_change> FindAll()
        {
            return dao.FindAll();
        }
    }
}
