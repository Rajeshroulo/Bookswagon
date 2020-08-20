using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bookswagon.Page
{
   public class BookSearch
   {
        public IWebDriver driver;
        public BookSearch(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-input']//input")]

        public IWebElement search;

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_Button1")]

        public IWebElement searchButton;

        
        [FindsBy(How = How.XPath, Using = "//div[1]//div[3]//div[1]//a[1]")]

        public IWebElement wings;

        public void BookSearching()
        {
            Thread.Sleep(3000);
            search.SendKeys("Wings of fire");
            searchButton.Click();
            Thread.Sleep(3000);
        } 

        public string BookTitle()
        {
            return wings.Text;
        }

   }
}
