using CommonToolLibary.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLibary
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dt1 = DateTime.Parse("2021/11/01 16:00:31");
            DateTime dt2 = DateTime.Parse("2021/11/01 16:00:36");

            var ts = Common.DateDiff(dt2, dt1);

            Console.WriteLine(ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒");

            Console.Read();
        }




    }
}
