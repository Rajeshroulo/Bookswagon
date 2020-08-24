using System;

namespace Bookswagon.exception
{
    public class Bookswagonexception : Exception
    {
        public string message;
        public ExceptionType type;

        public enum ExceptionType
        {
          REPORT_NOT_GENERATED,MAIL_NOT_SEND,INTERNET_NOT_CONNECTED,INCORRECT_PASSWORD,INCORRECT_MAIL,NO_BOOK_FOUND
        }

        public Bookswagonexception(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
