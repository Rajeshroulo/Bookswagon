using System;

namespace Bookswagon.Exceptions
{
    public class BookswagonException : Exception
    {
        public string message;
        public ExceptionType type;

        public enum ExceptionType
        {
          REPORT_NOT_GENERATED,MAIL_NOT_SEND,INTERNET_NOT_CONNECTED,INCORRECT_PASSWORD,INCORRECT_MAIL,NO_BOOK_FOUND
        }

        public BookswagonException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
            this.message = message;
        }
    }
}
