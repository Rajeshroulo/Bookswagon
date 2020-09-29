﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace Bookswagon.Page
{
    public class MyCartPage
    {
        public IWebDriver driver;
        public MyCartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//td[1]//div[1]//a[1]//input[1]")]
        public IWebElement buy;

        [FindsBy(How = How.XPath, Using = "//iframe[@class='cboxIframe']")]
        public IWebElement frame;

        [FindsBy(How = How.Id, Using = "BookCart_lvCart_imgPayment")]
        public IWebElement placeOrder;

        [FindsBy(How = How.ClassName, Using = "btn-red")]
        public IWebElement continueButton;

        [FindsBy(How = How.CssSelector, Using = "#ctl00_lblUser")]
        public IWebElement name;

        public void AddToShoppingCart()
        {
            buy.Click();
            Thread.Sleep(8000);
            driver.SwitchTo().Frame(frame);
            placeOrder.Click();
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(5000);
            continueButton.Click();
            Thread.Sleep(3000);
        }

        public string MailId()
        {
            return name.Text;
        }
    }   
}
