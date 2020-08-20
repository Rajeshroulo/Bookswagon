using Bookswagon.Base;
using Bookswagon.Data;
using Bookswagon.Page;
using NUnit.Framework;
using System;

namespace Bookswagon.Test
{
    public class BookswagonHome : BooksWagon
    {
        UserData data = new UserData();
        [Test,Order(1)]
        public void BookswagonLogin()
        {
            try
            {

                var login = new Login(driver);
                login.AccountLogin(data.email, data.bookspassword);

                Assert.AreEqual("TextBooks", login.TextBooks());

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        [Test,Order(2)]
        public void SearchBooks()
        {
            try
            {

                var search = new BookSearch(driver);
                search.BookSearching();

                string text = "Wings of Fire";
                Assert.AreEqual(text, search.BookTitle());

            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        [Test,Order(3)]
        public void AddtoCart()
        {
            try
            {

                var cart = new MyCart(driver);
                cart.ShoppingCart();

            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);

            }

        }

    }
}
