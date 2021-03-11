using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BankAdmin.Database;

namespace BankAdmin
{
    [TableName("user")]
    public class User 
    {

        public User GetSingleUser(string id)
        {
            return LoadUser(database.QueryToDictionary("select * from user where user_id = " + id, ClassReader.ClassToDictionary(typeof(User))));
        }
        public List<string> GetUserNames()
        {
            return database.List("select voornaam from user", "voornaam");
        }
        public List<User> GetUserNamesBankNumbers()
        {
            var result = new List<User>();
            var users = database.QueryToDictionaries("select user.user_id, voornaam, bank_rekeningnummer from user inner join bankdetails on user.user_id = bankdetails.user_id AND bankdetails.deleted_state = 0", new Dictionary<string, string>() { { "voornaam", "FirstName" }, { "user_id", "UserId" } }, "bank_rekeningnummer"); //you can use inline custom dictionaries to query specific collumns and save memory
            foreach (var user in users)
            {
                result.Add(LoadUser(user, "bank_rekeningnummer"));
            }
            return result;
        }
        public List<User> GetDeletedUserNamesBankNumbers()
        {
            var result = new List<User>();
            var users = database.QueryToDictionaries("select user.user_id, voornaam, bank_rekeningnummer from user inner join bankdetails on user.user_id = bankdetails.user_id AND bankdetails.deleted_state = 1", new Dictionary<string, string>() { { "voornaam", "FirstName" }, { "user_id", "UserId" } }, "bank_rekeningnummer"); //you can use inline custom dictionaries to query specific collumns and save memory
            foreach (var user in users)
            {
                result.Add(LoadUser(user, "bank_rekeningnummer"));
            }
            return result;
        }
        public string LastId()
        {
            return database.LastId("user", "user_id");
        }

        [FieldName("user_id",true,true)]
        public int UserId { get; set; }

        [FieldName("voornaam")]
        public string FirstName { get; set; }

        public string Password { get; set; }

        [FieldName("achternaam")]
        public string LastName { get; set; }

        [FieldName("email")]
        public string Email { get; set; }

        [FieldName("geslacht")]
        public string Gender { get; set; }

        [FieldName("straat")]
        public string Street { get; set; }

        [FieldName("postcode")]
        public string PostalCode { get; set; }

        [FieldName("stad")]
        public string City { get; set; }

        [FieldName("telefoonnummer")]
        public int Telephone { get; set; }

        public object JoinCollumns { get; set; }

       public User LoadUser(Dictionary<string,string> dict)
       {
           var user = new User();
           PropertyInfo[] props = typeof(User).GetProperties();
           foreach (PropertyInfo prop in props.Where(x=> x.CustomAttributes.Count()>0).Where(x => x.CustomAttributes.First().AttributeType == typeof(FieldName)))
           {
               if (prop.PropertyType == typeof(int))
               {
                   prop.SetValue(user, int.Parse(dict[prop.Name]));
               }
               else
               {
                   prop.SetValue(user, dict[prop.Name]);
               }
           }
           return user;
       }
        public User LoadUser(Dictionary<string, string> dict, params string[] customcols)
        {
            var user = new User();
            PropertyInfo[] props = typeof(User).GetProperties();
            foreach (PropertyInfo prop in props.Where(x=> x.CustomAttributes.Count() != 0).Where(x => x.CustomAttributes.First().AttributeType == typeof(FieldName)))
            {
                if (dict.ContainsKey(prop.Name))
                {
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(user, int.Parse(dict[prop.Name]));
                    }
                    else
                    {
                        prop.SetValue(user, dict[prop.Name]);
                    }
                }
            }
            var CustomCollumns = new Dictionary<string, string>();
            foreach(string cols in customcols)
            {
                CustomCollumns.Add(cols, dict[cols].ToString());
            }
            user.JoinCollumns = CustomCollumns;
            return user;
        }

    }
}
