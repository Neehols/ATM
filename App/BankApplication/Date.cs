using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace BankApplication
{
    public class Date
    {
        DateTime? Cache;
        public DateTime Now()
        {
            try
            {
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                myHttpWebRequest.Timeout = 2000;
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                Cache = DateTime.ParseExact(todaysDates,
                                           "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                                           CultureInfo.InvariantCulture.DateTimeFormat,
                                           DateTimeStyles.AssumeUniversal);
                return Cache ?? DateTime.Now;
            }
            catch
            {
                return Cache ?? DateTime.Now;
            }
        }
    }
                
}
