using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
