using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSpeedTest.Data.EF;


namespace DataSpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = DataHelper.LoadDataToDatatable();

        }
    }
}
