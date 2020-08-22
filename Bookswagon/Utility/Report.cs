using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Configuration;

namespace Bookswagon.Utility
{
    public  class Report
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;

        public static ExtentReports GetReport()
        {
            string reportPath = ConfigurationManager.AppSettings["Path"];
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;
        }
    }
}
