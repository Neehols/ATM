using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BankApplication
{
    public class Database
    {
        public static Database database;
        private string ConnectionString = "";
        public Database(string conn)
        {
            ConnectionString = conn;
            database = this;
        }

        public MySqlConnection Connect()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                connection.Open();
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            return connection;
        }

        public List<string> List(string query, string collumn)
        {
            List<string> result = new List<string>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[collumn].ToString());
                        }
                    }
                }
            }
            return result;
        }
        public void CustomQuery(string query)
        {
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string SingleResultQuery(string query)
        {
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;
                    var result = cmd.ExecuteScalar();
                    return result == null ? "" : result.ToString();
                }
            }
        }
        
        public Dictionary<string, string> QueryToDictionary(string query, Dictionary<string, string> dict)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        foreach (string key in dict.Keys)
                        {
                            result.Add(dict[key], reader[key].ToString());
                        }

                    }
                }
            }
            return result;

        }
        public Dictionary<string, string> QueryToDictionary(string query, Dictionary<string, string> dict, params string[] customcols)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        foreach (string key in dict.Keys)
                        {
                            result.Add(dict[key], reader[key].ToString());
                        }
                        foreach (string col in customcols)
                        {
                            result.Add(col, reader[col].ToString());
                        }

                    }
                }
            }
            return result;
        }
        public List<Dictionary<string, string>> QueryToDictionaries(string query, Dictionary<string, string> dict, params string[] customcols)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            using (MySqlConnection connection = Connect())
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 300;
                    cmd.CommandText = query;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tempDict = new Dictionary<string, string>();
                            foreach (string key in dict.Keys)
                            {
                                tempDict.Add(dict[key], reader[key].ToString());
                            }
                            foreach (string col in customcols)
                            {
                                tempDict.Add(col, reader[col].ToString());
                            }
                            result.Add(tempDict);
                        }

                    }
                }
            }
            return result;
        }
    }
}
