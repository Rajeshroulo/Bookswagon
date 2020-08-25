using Bookswagon.Base;
using Bookswagon.Data;
using Bookswagon.Exceptions;
using Bookswagon.Page;
using NUnit.Framework;
using System;

namespace Bookswagon.Test
{
    public class BookswagonTests : BaseClass
    {
        UserData data = new UserData();
        [Test,Order(1)]
        public void BookswagonLogin()
        {           
             var login = new LoginPage(driver);
             login.AccountLogin(data.email, data.bookspassword);
             Assert.AreEqual("TextBooks", login.TextBooks());             
        }

        [Test,Order(2)]
        public void BookSearching()
        {
            try
            {
                var search = new SearchingBooksPage(driver);
                search.FindBook();
            }
            catch (BookswagonException e)
            {
                throw new BookswagonException(BookswagonException.ExceptionType.NO_BOOK_FOUND, "Search did not match any books ");
            }
        } 

        [Test,Order(3)]
        public void SearchBooks()
        {
             var search = new BookSearchPage(driver);
             search.BookSearching();
             string text = "Wings of Fire #02: The Lost Heir";
             Assert.AreEqual(text, search.BookTitle());                       
        }

        [Test,Order(4)]
        public void AddtoCart()
        {           
             var cart = new MyCartPage(driver);
             cart.AddToShoppingCart();
             string mail = "Hi, rajraval017@gmail.com";
             Assert.AreEqual(mail, cart.MailId());
        }

        [Test,Order(5)]
        public void DeliveryAddress()
        {
            var address = new AddressPage(driver);
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
                var login = new BookswagonLoginPage(driver);
                login.LoginAccount();
            }
            catch(BookswagonException e)
            {
                throw new BookswagonException(BookswagonException.ExceptionType.INCORRECT_PASSWORD, "Password is wrong");
            }
            
        }

        [Test,Order(7)]
        public void UserLogin()
        {
            try
            {
                var login = new UserLoginPage(driver);
                login.Login();
            }
            catch (BookswagonException e)
            {
                throw new BookswagonException(BookswagonException.ExceptionType.INCORRECT_MAIL, "Mail is wrong");
            }
        } 
    }
}
