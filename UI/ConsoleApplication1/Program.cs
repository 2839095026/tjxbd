using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            HR_DBEntities1 adt = new HR_DBEntities1();
        var l=    adt.config_major.GroupBy(e => e.major_kind_id);
           

        }
    }
}
