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
    public class EngageExamBll : IEngageExamBll
    {
        IEngageExamDao<engage_exam> dao = IocCreate.CreateDao<IEngageExamDao<engage_exam>>("EngageExamDao");

        public int Add(engage_exam t)
        {
            return dao.Add(t);
        }

        public int Change(engage_exam t)
        {
            return dao.Change(t);
        }

        public int Del(engage_exam t)
        {
            return dao.Del(t);
        }

        public List<engage_exam> FindAll()
        {
            return dao.FindAll();
        }
    }
}
