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

        public enum ExceptionType
        {
          
        }
        public ExceptionType type;

        public Bookswagonexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }

    }
}
