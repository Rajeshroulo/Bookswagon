using Bookswagon.Base;
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
        [Test]
        public void BookswagonLogin()
        {
            var login = new Login(driver);
            login.AccountLogin();
        }

   }
}
