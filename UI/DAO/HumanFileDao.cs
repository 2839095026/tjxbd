
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using IDAO;
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
    }
}
