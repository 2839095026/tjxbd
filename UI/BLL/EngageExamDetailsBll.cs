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
    //IBLL.IEngageExamDetailsBll bll = IocContainer.IocCreate.CreateBll<IBLL.IEngageExamDetailsBll>("EngageExamDetailsBll");

    public class EngageExamDetailsBll : IEngageExamDetailsBll
    {
       IEngageExamDetailsDao<engage_exam_details> dao = IocCreate.CreateDao<IEngageExamDetailsDao<engage_exam_details>>("EngageExamDetailsDao");

        public int Add(engage_exam_details t)
        {
            return dao.Add(t);
        }

        public int Change(engage_exam_details t)
        {
            return dao.Change(t);
        }

        public int Del(engage_exam_details t)
        {
            return dao.Del(t);
        }

        public List<engage_exam_details> FindAll()
        {
            return dao.FindAll();
        }
    }
}
