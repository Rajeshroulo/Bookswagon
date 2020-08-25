using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace Bookswagon.Page
{
    public class BookSearchPage
    {
        public IWebDriver driver;
        public BookSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-input']//input")]
        public IWebElement search;

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_Button1")]
        public IWebElement searchButton;
        
        [FindsBy(How = How.XPath, Using = "//div[1]//div[3]//div[1]//a[1]")]
        public IWebElement wingsOfFire;

        public void BookSearching()
        {
            Thread.Sleep(2000);
            search.SendKeys("Wings of fire");
            searchButton.Click();
            Thread.Sleep(3000);
        } 

        public string BookTitle()
        {
            return wingsOfFire.Text;
        }
    }
}
