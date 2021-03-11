using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAdmin
{
    public class SQL
    {
        Database database;
        public SQL(Database db)
        {
            database = db;
        }

        public void InsertClass(Type t, object instance)
        {
            var collumns = ClassReader.FieldNames(t);
            var values = ClassReader.ValuesList(t, instance);
            var sb = new StringBuilder();
            var sb2 = new StringBuilder();
            foreach(string collumn in collumns)
            {
                sb.Append(collumn + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            foreach (string value in values)
            {
                if(value=="")
                    sb2.Append("'0'" + ",");
                else
                    sb2.Append("'"+value+"'" + ",");
            }
            sb2.Remove(sb2.Length - 1, 1);
            var tablename = t.GetCustomAttributes(true).OfType<TableName>().First().value;
            string query = String.Format("INSERT INTO {0} ({1}) VALUES({2})",tablename,sb.ToString(),sb2.ToString());
            database.CustomQuery(query);
        }
        public void EditClass(Type t, object instance)
        {
            Field Id = ClassReader.IdInfo(t, instance);
            var collumns = ClassReader.FieldNames(t);
            var values = ClassReader.ValuesList(t, instance);
            var sb = new StringBuilder();
            for (int i = 0; i < collumns.Count; i++)
            {
                sb.Append(collumns[i] + "=" + "'"+values[i]+"'" + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            var tablename = t.GetCustomAttributes(true).OfType<TableName>().First().value;
            string query = String.Format("UPDATE {0} SET {1} WHERE {2}={3}", tablename, sb.ToString(), Id.Name, Id.Value);
            database.CustomQuery(query);
        }


    }
}
