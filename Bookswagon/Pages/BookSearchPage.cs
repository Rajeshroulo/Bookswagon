using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        
        [FindsBy(How = How.Id, Using = "ctl00_phBody_ProductDetail_lblTitle")]
        public IWebElement wingsOfFire;

        public void BookSearching()
        {
            Thread.Sleep(1000);
            search.SendKeys(ConfigurationManager.AppSettings["BookName"]);
            searchButton.Click();
            Thread.Sleep(3000);
            IList<IWebElement> books = driver.FindElements(By.XPath("//a[contains(text(),'Wings of Fire')]"));
            foreach(var book in books)
            {
                Console.WriteLine(book.Text);
            }
            books[1].Click();
            Thread.Sleep(3000);
        }

        public string BookTitle()
        {
            return wingsOfFire.Text;
        }
    }
}
