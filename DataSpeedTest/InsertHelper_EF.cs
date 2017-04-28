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

        public static void InsertFromListByLinq(List<TargetTable1> list)
        {
            string connectString = System.Configuration.configurationm .ConfigurationManager.ConnectionStrings["LinqToSQLDBConnectionString"].ToString();
            LinqToSQLDataContext db = new LinqToSQLDataContext(connectString);
        }

        //public static void InsertFromListByExtension(List<TargetTable1> list, int bulkSize = 0)
        //{
        //    using (var db = new TestEntities())
        //    {
        //        db.TargetTable1.AddRange(list); // add
        //        if (bulkSize == 0)
        //            db.BulkSaveChanges();
        //        else
        //            db.BulkSaveChanges(bulk => bulk.BatchSize = bulkSize);
        //    }
        //}

    }
}
