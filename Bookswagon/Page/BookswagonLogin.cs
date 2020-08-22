using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public  class BookswagonLogin
    {
        public IWebDriver driver;
        public BookswagonLogin(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtEmail")]
        public IWebElement mail;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$txtPassword")]
        public IWebElement bookPassword;

        [FindsBy(How = How.Name, Using = "ctl00$phBody$SignIn$btnLogin")]
        public IWebElement loginButton;

        public void LoginAccount()
        {
            Thread.Sleep(3000);
            mail.SendKeys("rajraval@gmail.com");
            bookPassword.SendKeys("Rajesh");
            loginButton.Click();
            Thread.Sleep(3000);
        }
    }
}
