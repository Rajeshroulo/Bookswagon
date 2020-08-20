using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookswagon.Base
{
   public class BooksWagon
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications", "start-maximized");
            driver = new ChromeDriver(options);
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
