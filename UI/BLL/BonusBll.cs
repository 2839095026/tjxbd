using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Entity;
using System.Linq.Expressions;
using IocContainer;
using IDAO;
namespace BLL
{
    //IBLL.IBonusBll bll = IocContainer.IocCreate.CreateBll<IBLL.IBonusBll>("BonusBll");
    public class BonusBll : IBonusBll
    {
        IBonusDao<bonus> dao = IocCreate.CreateDao<IBonusDao<bonus>>("BonusDao");

        public int Add(bonus t)
        {
            return dao.Add(t);
        }
        public int Change(bonus t)
        {
            return dao.Change(t);
        }

        public int Del(bonus t)
        {
            return dao.Del(t);
        }

        public List<bonus> FindAll()
        {
            return dao.FindAll();
        }
    }
}
