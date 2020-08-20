using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public void ShippingAddress()
        {
            Thread.Sleep(3000);
            name.SendKeys(ConfigurationManager.AppSettings["Name"]);
            company.SendKeys(ConfigurationManager.AppSettings["Company"]);
            addres.SendKeys(ConfigurationManager.AppSettings["Address"]);
            SelectElement element = new SelectElement(state);
            element.SelectByText("Andhra Pradesh");
            pin.SendKeys(ConfigurationManager.AppSettings["Pin"]);
            mobile.SendKeys(ConfigurationManager.AppSettings["Mobile"]);
            save.Click();
        }


    }
}
