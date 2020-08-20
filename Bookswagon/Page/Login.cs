using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public class Login
    {
        public IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Login')]")]

        public IWebElement loginoption;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtEmail")]

        public IWebElement mail;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtPassword")]

        public IWebElement bookpassword;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$btnLogin")]

        public IWebElement loginbutton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'TextBooks')]")]

        public IWebElement textBooks;



        public void AccountLogin(string email, string bookspassword)
        {
            loginoption.Click();
            Thread.Sleep(3000);
            mail.SendKeys(email);
            bookpassword.SendKeys(bookspassword);
            loginbutton.Click();
            Thread.Sleep(3000);
        }

        public string TextBooks()
        {
            return textBooks.Text;
        }
    }
}
