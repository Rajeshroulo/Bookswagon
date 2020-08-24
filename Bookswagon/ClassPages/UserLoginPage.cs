using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public class BooksLogin
    {
        public IWebDriver driver;
        public BooksLogin(IWebDriver driver)
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

        public void Login()
        {
            loginOption.Click();
            Thread.Sleep(2000);
            mail.SendKeys("raj@ gmail.com");
            bookPassword.SendKeys("devtune");
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }
}
