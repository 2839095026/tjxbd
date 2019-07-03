using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAO;
using Entity;
using System.Data;
using System.Linq.Expressions;

namespace DAO
{
    public class MajorChangeDao:BaseDao<major_change>,IMajorChangeDao<major_change>
    {
       public  DataTable Selectfirst(string fileName) {

            string sql = " select new_first_kind_id,new_first_kind_name from dbo.major_change group by new_first_kind_id,new_first_kind_name";
            return DBHelper.Select(sql,fileName);
           
        }

       public  DataTable SelectSecond(string id, string fileName)
        {
            string sql = string.Format("select new_second_kind_id,new_second_kind_name from dbo.major_change  where  new_first_kind_id='{0}' group by new_second_kind_id,new_second_kind_name", id, fileName);
            return DBHelper.Select(sql, fileName);
        }
     public    DataTable SelectThird(string id, string fileName)
        {
            string sql = string.Format("select new_third_kind_id, new_third_kind_name  from dbo.major_change where new_second_kind_id = '{0}' group by new_third_kind_id, new_third_kind_name", id,fileName);
            return DBHelper.Select(sql, fileName);
        }
        public string FindID()
        {
            var v = GetAdt().OrderByDescending(e => e.regist_time).Take(1).ToList().FirstOrDefault();
            return v != null ? v.human_id : "";
        }

      public   DataTable Selectkind_name(string fileName) {
            string sql = "select new_major_kind_id,new_major_kind_name from dbo.major_change  group by new_major_kind_id,new_major_kind_name ";
            return DBHelper.Select(sql,fileName);

        }

      public  DataTable Selectmajor_name(string id, string fileName)
        {
            string sql = string.Format("select new_major_id,new_major_name from dbo.major_change where new_major_kind_id='{0}' group by  new_major_id,new_major_name", id);
            return DBHelper.Select(sql, fileName);
        }

      public   DataTable SelectSan(string id, string fileName)
        {
            string sql = string.Format("select new_major_kind_id,new_major_kind_name from major_change where third_kind_id='{0}' group by new_major_kind_id,new_major_kind_name", id);
            return DBHelper.Select(sql, fileName);
        }
     
    }
}
