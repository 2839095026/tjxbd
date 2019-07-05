
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
using System.Data;

namespace DAO
{
    public class HumanFileDao : BaseDao<human_file>, IHumanFileDao<human_file>
    {
        public List<human_file> FindAllHumanFileByState(int pageInxex, int pageSize, out int count, Expression<Func<human_file, bool>> where)
        {
            return base.FenYe<int>(pageInxex, pageSize, out count, where, e => e.huf_id);
        }

        public List<human_file> FindCheckList(int pageInxex, int pageSize, out int count)
        {
            return base.FenYe<int>(pageInxex, pageSize, out count, e => e.check_status.ToString().Equals("0"), e => e.huf_id);
        }

        public human_file FindHumanFileByHumanId(string humanid)
    {
            return SelectWhere(e => e.human_id.Equals(humanid)).ToList().FirstOrDefault();
        }
        public DataTable Selectfirst(string fileName)
        {

            string sql = "select first_kind_id,first_kind_name from  dbo.human_file  group by first_kind_id,first_kind_name ";
            return DBHelper.Select(sql, fileName);

        }

        public DataTable SelectSecond(string id, string fileName)
        {
            string sql = string.Format("select second_kind_id,second_kind_name from  dbo.human_file  where  first_kind_id='{0}' group by  second_kind_id,second_kind_name", id, fileName);
            return DBHelper.Select(sql, fileName);
        }
        public DataTable SelectThird(string id, string fileName)
        {
            string sql = string.Format("select third_kind_id,third_kind_name  from  dbo.human_file where second_kind_id='{0}' group by third_kind_id,third_kind_name", id, fileName);
            return DBHelper.Select(sql, fileName);
        }
    }
}
