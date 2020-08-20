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
             var login = new Login(driver);
             login.AccountLogin(data.email, data.bookspassword);

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

        [Test,Order(3)]
        public void AddtoCart()
        {           
             var cart = new MyCart(driver);
             cart.ShoppingCart();           
        }

        [Test,Order(4)]
        public void DeliveryAddress()
        {
            var address = new Address(driver);
            address.ShippingAddress();
            address.Payment();

            string expected = "TextBooks";
            Assert.AreEqual(expected, address.Books());
        }

    }
}
