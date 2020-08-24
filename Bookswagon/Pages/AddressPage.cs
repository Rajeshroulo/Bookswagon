using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Configuration;
using System.Threading;

namespace Bookswagon.Page
{
    public class Address
    {
        public IWebDriver driver;
        public Address(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "ctl00$cpBody$txtNewRecipientName")]
        public IWebElement name;

        [FindsBy(How = How.Id, Using = "ctl00_cpBody_txtNewCompanyName")]
        public IWebElement company;

        [FindsBy(How = How.XPath, Using = "//div[4]//div[2]//textarea[1]")]
        public IWebElement addres;

        [FindsBy(How = How.XPath, Using = "//div[6]//div[2]//div[1]//select[1]")]
        public IWebElement state;

        [FindsBy(How = How.Name, Using = "ctl00$cpBody$txtNewCity")]
        public IWebElement city;

        [FindsBy(How = How.Name, Using = "ctl00$cpBody$txtNewPincode")]
        public IWebElement pin;

        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//input[1]")]
        public IWebElement mobile;

        [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//input[1]")]
        public IWebElement save;

        [FindsBy(How = How.XPath, Using = "//input[@class='btn-red']")]
        public IWebElement next;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Logout')]")]
        public IWebElement logout;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'TextBooks')]")]
        public IWebElement books;

        public void ShippingAddress()
        {
            Thread.Sleep(3000);
            name.SendKeys(ConfigurationManager.AppSettings["Name"]);
            company.SendKeys(ConfigurationManager.AppSettings["Company"]);
            addres.SendKeys(ConfigurationManager.AppSettings["Address"]);
            SelectElement element = new SelectElement(state);
            element.SelectByText("Andhra Pradesh");
            city.SendKeys(ConfigurationManager.AppSettings["City"]);
            pin.SendKeys(ConfigurationManager.AppSettings["Pin"]);
            mobile.SendKeys(ConfigurationManager.AppSettings["Mobile"]);
            save.Click();
            Thread.Sleep(4000);
        }

        public void Payment()
        {
            next.Click();
            Thread.Sleep(6000);
            logout.Click();
            Thread.Sleep(2000);
        }

        public string Books()
        {
            return books.Text;
        }
    }
}
