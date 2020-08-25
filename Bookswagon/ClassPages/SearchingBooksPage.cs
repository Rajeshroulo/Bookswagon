using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public class SearchingBooksPage
    {
        public IWebDriver driver;
        public SearchingBooksPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='search-input']//input")]
        public IWebElement search;

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_Button1")]
        public IWebElement searchButton;

        public void FindBook()
        {
            Thread.Sleep(2000);
            search.SendKeys("nfg");
            searchButton.Click();
            Thread.Sleep(3000);
        }
    }
}
