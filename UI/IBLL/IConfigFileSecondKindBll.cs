using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq.Expressions;

namespace IBLL
{
    public interface IConfigFileSecondKindBll
    {
        List<config_file_second_kind> FindAll();
        int Add(config_file_second_kind t);
        int Del(config_file_second_kind t);
        int Change(config_file_second_kind t);
        /// <summary>
        /// 根据一级机构编号获取对应的二级机构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<config_file_second_kind> GetConfigFileSecondKindByFKID(string fkid);
    }
}
