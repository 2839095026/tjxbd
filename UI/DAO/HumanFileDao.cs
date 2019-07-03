
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using System.Data;

namespace DAO
{
    public class HumanFileDao:BaseDao<human_file>,IHumanFileDao<human_file>
    {
        public DataTable Selectfirst(string fileName)
        {

            string sql = "select first_kind_id,first_kind_name from  dbo.human_file ";
            return DBHelper.Select(sql, fileName);

        }

        public DataTable SelectSecond(string id, string fileName)
        {
            string sql = string.Format("select second_kind_id,second_kind_name from  dbo.human_file  where  first_kind_id='{0}'", id, fileName);
            return DBHelper.Select(sql, fileName);
        }
        public DataTable SelectThird(string id, string fileName)
        {
            string sql = string.Format("select third_kind_id,third_kind_name  from  dbo.human_file where second_kind_id='{0}'", id, fileName);
            return DBHelper.Select(sql, fileName);
        }
    }
}
