using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookswagon.Data
{
   public class UserData
   {
        public string email;
        public string password;
        public string json;
        public string bookspassword;
        public UserData()
        {
            using (StreamReader reader = new StreamReader(ConfigurationManager.AppSettings["JSON"]))
            {
                json = reader.ReadToEnd();
            }

            dynamic a = JsonConvert.DeserializeObject(json);
            email = a["email"];
            password = a["password"];
            bookspassword = a["bookspassword"];
        }

    }
}
