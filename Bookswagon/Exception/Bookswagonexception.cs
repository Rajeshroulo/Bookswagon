using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookswagon.exception
{
   public class Bookswagonexception : Exception
   {
        public string message;
        public ExceptionType type;

        public enum ExceptionType
        {
          REPORT_NOT_GENERATED,MAIL_NOT_SEND,INTERNET_NOT_CONNECTED
        }

        public Bookswagonexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }

   }
}
