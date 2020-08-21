using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookswagon
{
    public class Screenshots
    {
        public static string TakePhoto(IWebDriver driver, string ScreenShotName)
        {
            String time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            var ts = ((ITakesScreenshot)driver).GetScreenshot();
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            String uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshot Photos\\" + (ScreenShotName + "   " + time) + ".png";
            String localPath = new Uri(uptobinpath).LocalPath;
            ts.SaveAsFile(localPath, ScreenshotImageFormat.Png); 
            return localPath;
        }
    }
}
