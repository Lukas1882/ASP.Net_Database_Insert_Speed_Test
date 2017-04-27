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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var elapsedMs = watch.ElapsedMilliseconds;
            var recordsList = DataHelper.ParseList(DataHelper.LoadDataToList());
            var recordsDb  = DataHelper.LoadDataToDatatable();

            //list EF Ranch
            DataHelper.CleanTargetTable();
            watch = System.Diagnostics.Stopwatch.StartNew();
            InsertHelper_EF.InsertFromListByRange(recordsList);
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("List - EF - Range Insert :" + elapsedMs + " ms");
            //list EF Buck
            DataHelper.CleanTargetTable();
            watch = System.Diagnostics.Stopwatch.StartNew();
            InsertHelper_EF.InsertFromListByEFUtiInserAll(recordsList);
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("List - EF - Bulk Insert :" + elapsedMs + " ms");
            ////list EF Buck extension
            //DataHelper.CleanTargetTable();
            //watch = System.Diagnostics.Stopwatch.StartNew();
            //InsertHelper_EF.InsertFromListByExtension(recordsList);
            //elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine("List - EF - Extension Insert :" + elapsedMs + " ms");

            Console.ReadLine();
        }
    }
}
