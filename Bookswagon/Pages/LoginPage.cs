using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public class LoginPage
    {
        public IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Login')]")]
        public IWebElement loginOption;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtEmail")]
        public IWebElement mail;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtPassword")]
        public IWebElement bookPassword;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$btnLogin")]
        public IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'TextBooks')]")]
        public IWebElement textBooks;

        public void AccountLogin(string email, string bookspassword)
        {
            loginOption.Click();
            Thread.Sleep(3000);
            mail.SendKeys(email);
            bookPassword.SendKeys(bookspassword);
            loginButton.Click();
            Thread.Sleep(3000);
        }

        public string TextBooks()
        {
            return textBooks.Text;
        }
    }
}
