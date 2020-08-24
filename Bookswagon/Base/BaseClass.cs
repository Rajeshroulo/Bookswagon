using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Bookswagon.Email;
using Bookswagon.exception;
using Bookswagon.Utility;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace Bookswagon.Base
{
    public class BaseClass
    {
        public static ExtentReports extent = Report.GetReport();
        public static ExtentTest test;
        Mailing mail = new Mailing();
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;

        [OneTimeSetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications", "start-maximized");
            driver = new ChromeDriver(options);
            driver.Url = ConfigurationManager.AppSettings["URL"];           
        }

        [SetUp]
        public void NetConnection()
        {
            try
            {
                Console.WriteLine("Internet Connected =" + InternetConnectionTest.IsConnectedToInternet());
            }
            catch (Bookswagonexception e)
            {
                throw new Bookswagonexception(Bookswagonexception.ExceptionType.INTERNET_NOT_CONNECTED, "Internet connection not available");
            }
        }                

        [TearDown]
        public void ExtentClose()
        {
            var errorMessage = TestContext.CurrentContext.Result.Message;
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                try
                {
                    test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Green));
                    test.Log(Status.Pass, "Test Passed");
                    log.Info("Test is Passed");
                }
                catch (Bookswagonexception e)
                {
                    throw new Bookswagonexception(Bookswagonexception.ExceptionType.REPORT_NOT_GENERATED, "Reports are not generated");
                }
                
            }

            else if(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string path = Screenshots.TakePhoto(driver, TestContext.CurrentContext.Test.Name + "   " + "Failed");
                test.AddScreenCaptureFromPath(path);
                test.Pass(MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name, ExtentColor.Red));
                test.Log(Status.Fail, "Test Failed");
                log.Info("Test is Failed");
            }
            extent.Flush();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            try
            {
                mail.SendMail("Test Results", TestContext.CurrentContext.Test.Name);
            }
            catch (Bookswagonexception e)
            {
                throw new Bookswagonexception(Bookswagonexception.ExceptionType.MAIL_NOT_SEND, e.Message);
            }
        }
    }
}
