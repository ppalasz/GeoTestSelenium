using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests1
{
    public static class SeleniumTestHelpLibrary
    {
        public static void TakeScreenshot(object driver,string subfolder, string title)
        {
            title = title.Replace(" ", "_");
            string folder = $"{System.IO.Path.GetFullPath(@"..\..\")}\\screenshots\\{subfolder}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string file = $"TestScreenShot_{DateTime.Now.ToShortDateString().Replace(":","_")}_{DateTime.Now.ToShortTimeString().Replace(":", "_")}.jpg";
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile($"{folder}\\{file}", ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("window-size=1920,1080"); // open Browser in maximized mode
            //options.AddArgument("disable-infobars"); // disabling infobars
            //options.AddArgument("--disable-extensions"); // disabling extensions
            //options.AddArgument("--disable-gpu"); // applicable to windows os only
            //options.AddArgument("--disable-dev-shm-usage"); // overcome limited resource problems
            //options.AddArgument("--no-sandbox"); // Bypass OS security model

            return (options);
        }
    }
}
