using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace IocContainer
{
    public class IocCreate
    {
        /// <summary>
        /// 创建dao层
        /// </summary>
        /// <typeparam name="T">创建类型</typeparam>
        /// <param name="name">register名称</param>
        /// <returns></returns>
        public static T CreateDao<T>(string name)
        {

            UnityContainer ioc = CreatIoc("containerDAO");
            T rt = ioc.Resolve<T>(name);
            return rt;
        }

        private static UnityContainer CreatIoc(string name)
        {
            UnityContainer ioc = new UnityContainer();
            ExeConfigurationFileMap exf = new ExeConfigurationFileMap();
            exf.ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory + "Unity.config";
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exf, ConfigurationUserLevel.None);
            UnityConfigurationSection cfs = (UnityConfigurationSection)cf.GetSection("unity");
            ioc.LoadConfiguration(cfs, name);
            return ioc;
        }

        public static T CreateBll<T>(string name)
        {
            UnityContainer ioc = CreatIoc("containerBLL");
            T rt = ioc.Resolve<T>(name);
            return rt;
        }

    }
}
