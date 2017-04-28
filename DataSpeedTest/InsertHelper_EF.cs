using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataSpeedTest.Data.EF;
using EntityFramework.Utilities;
using System.Linq;
using System.Configuration;

namespace DataSpeedTest
{
    class InsertHelper_EF
    {
        public static void InsertFromListByRange(List<TargetTable1> list)
        {
            using (var db = new TestEntities())
            {
                db.TargetTable1.AddRange(list);
                db.SaveChanges();
            }
        }

        public static void InsertFromListByEFUtiInserAll(List<TargetTable1> list)
        {
            using (var db = new TestEntities())
            {
                EFBatchOperation.For(db, db.TargetTable1).InsertAll(list);
            }
        }



    }
}
