using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSpeedTest.Data.EF;

namespace DataSpeedTest
{
    class DataHelper
    {
        public static List<SourceTable1> LoadDataToList()
        {
            using (var context = new TestEntities())
            {
                // Query for all blogs with names starting with B 
                var records = (from r in context.SourceTable1 select r);// context.SourceTable1.Select(r =>r.col1 != null);   // from b in context.TargetTable1 select b;
                var dd = records.AsEnumerable<SourceTable1>().ToList();
             
            }

            return null;
        }
    }
}
