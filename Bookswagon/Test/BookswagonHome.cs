using Bookswagon.Base;
using Bookswagon.Data;
using Bookswagon.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookswagon.Test
{
   public class BookswagonHome : BooksWagon
    {
        UserData data = new UserData();
        [Test,Order(1)]
        public void BookswagonLogin()
        {
            var login = new Login(driver);
            login.AccountLogin(data.email,data.bookspassword);

            Assert.AreEqual("TextBooks", login.TextBooks());
        }

        [Test,Order(2)]
        public void SearchBooks()
        {
            var search = new BookSearch(driver);
            search.BookSearching();

            string text = "Wings of Fire";
            Assert.AreEqual(text, search.BookTitle());
        }

   }
}
