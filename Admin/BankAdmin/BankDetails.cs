using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static BankAdmin.Database;

namespace BankAdmin
{
    [TableName("bankdetails")]
    public class BankDetails
    {
        [FieldName("bank_nummer_id", true)]
        public int BankDetailsId { get; set; }

        [FieldName("bank_rekeningnummer")]
        public Int64 BankAccountNumber { get; set; }

        [FieldName("saldo")]
        public double BankBalance { get; set; }

        [FieldName("pin")]
        public string BankAccountPin { get; set; }

        [FieldName("user_id")]
        public string UserId { get; set; }

        public static void UpdatePin(string newPin, string id)
        {
            database.CustomQuery(String.Format("UPDATE bankdetails SET pin='{0}' WHERE user_id={1}", newPin, id));
        }
        public static void ChangeAccountState(string id)
        {

            database.CustomQuery(String.Format("UPDATE bankdetails SET deleted_state=NOT deleted_state WHERE user_id={0}", id));
        }

    }
}

