using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IBLL;
using IDAO;
using IocContainer;
using System.Data;

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
        public List<major_change> FenYe(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<int>(pageIndex, pageSize, out Count, e => e.mch_id != 0 , e => e.mch_id);
        }

     public DataTable Selectfirst(string fileName)
        {
            return dao.Selectfirst(fileName);
        }

        public DataTable SelectSecond(string id, string fileName)
        {
            return dao.SelectSecond(id,fileName);
        }
        public DataTable SelectThird(string id, string fileName)
        {
            return dao.SelectThird(id,fileName);
        }
        public string FindID()
        {
            return dao.FindID();
        }
        public List<major_change> SelectWhere(string id)
        {
            return dao.SelectWhere(t =>t.human_id == id);
        }
        public List<major_change> FenYesh(int pageIndex, int pageSize, out int Count)
        {
            return dao.FenYe<int>(pageIndex, pageSize, out Count, e => e.check_status==0, e => e.mch_id);
        }
        public DataTable Selectkind_name(string fileName)
        {
            return dao.Selectkind_name(fileName);

        }

        public DataTable Selectmajor_name(string id, string fileName)
        {
            return dao.Selectmajor_name(id,fileName);
        }
        public DataTable SelectSan(string id, string fileName)
        {
            return dao.SelectSan(id,fileName);
        }
        public List<major_change> SelectWhereType(string id)
        {
            return dao.SelectWhere(t => t.first_kind_id == id);
        }
        public List<major_change> SelectWhere(int id)
        {
            return dao.SelectWhere(t => t.mch_id == id);
        }
    }
}
