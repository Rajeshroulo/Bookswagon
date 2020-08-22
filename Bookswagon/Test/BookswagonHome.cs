using Bookswagon.Base;
using Bookswagon.Data;
using Bookswagon.exception;
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
             var login = new Login(driver);
             login.AccountLogin(data.email, data.bookspassword);

             Assert.AreEqual("TextBooks", login.TextBooks());             
        }

        [Test,Order(2)]
        public void BookSearching()
        {
            try
            {
                var search = new SearchingBooks(driver);
                search.FindBook();
            }
            catch (Bookswagonexception e)
            {
                throw new Bookswagonexception(Bookswagonexception.ExceptionType.NO_BOOK_FOUND, "Search did not match any books ");
            }

        }

        [Test,Order(3)]
        public void SearchBooks()
        {
             var search = new BookSearch(driver);
             search.BookSearching();
             string text = "Wings of Fire";
             Assert.AreEqual(text, search.BookTitle());                       
        }

        [Test,Order(4)]
        public void AddtoCart()
        {           
             var cart = new MyCart(driver);
             cart.AddToShoppingCart();
             string mail = "Hi, rajraval017@gmail.com";
             Assert.AreEqual(mail, cart.MailId());
        }

        [Test,Order(5)]
        public void DeliveryAddress()
        {
            var address = new Address(driver);
            address.ShippingAddress();
            address.Payment();
            string expected = "TextBooks";
            Assert.AreEqual(expected, address.Books());
        } 

        [Test,Order(6)]
        public void Login()
        {
            try
            {
                var login = new BookswagonLogin(driver);
                login.LoginAccount();
            }
            catch(Bookswagonexception e)
            {
                throw new Bookswagonexception(Bookswagonexception.ExceptionType.INCORRECT_PASSWORD, "Password is wrong");
            }
            
        }

        [Test,Order(7)]
        public void Logins()
        {
            try
            {
                var login = new BooksLogin(driver);
                login.Login();
            }
            catch (Bookswagonexception e)
            {
                throw new Bookswagonexception(Bookswagonexception.ExceptionType.INCORRECT_MAIL, "Mail is wrong");
            }

        }

    }
}
