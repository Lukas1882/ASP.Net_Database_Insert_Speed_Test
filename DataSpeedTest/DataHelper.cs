using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSpeedTest.Data.EF;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;
using Newtonsoft.Json;

namespace DataSpeedTest
{
    public static class DataHelper
    {
        public static List<SourceTable1> LoadDataToList()
        {
            using (var context = new TestEntities())
            {
                var records = (from r in context.SourceTable1 select r);// context.SourceTable1.Select(r =>r.col1 != null);   // from b in context.TargetTable1 select b;
                return records.AsEnumerable<SourceTable1>().ToList();
            }
        }

        public static DataTable LoadDataToDatatable()
        {
            var list = LoadDataToList();
            return ToDataTable(list);
        }


        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void CleanTargetTable()
        {
            using (var context = new TestEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Test].[dbo].[TargetTable1]");
            }
        }

        public static List<TargetTable1> ParseList(List<SourceTable1> list)
        {
            var json = JsonConvert.SerializeObject(list);
            return JsonConvert.DeserializeObject<List<TargetTable1>>(json);
        }


    }
}
