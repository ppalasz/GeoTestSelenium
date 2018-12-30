using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumTests1
{
    [TestClass]
    public class GNSS_definicja : TestGeo
    {
        

        //[ExpectedException(typeof(ArgumentException))]
        //[Timeout(TestTimeout.Infinite)]  // Milliseconds
        [TestMethod]
        public void PagingArticle()
        {
            testName = "PageParts";

            using (var driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();
                string url1 = $"{www}/GNSS/definicja";
                driver.Navigate().GoToUrl(url1);
                string url2 = driver.Url;
                Assert.AreEqual(url1, url2, $"1) link '{url1}' must be navigated to");

                var submenu = driver.FindElementById("submenu");
                Assert.IsNotNull(submenu, @"submenu must exist");

                var chosenMenu = driver.FindElementByClassName("chosen_menu");
                Assert.IsNotNull(chosenMenu, @"GNSS/definicja must be chosen");
                chosenMenu.Click();
                url2=driver.Url;
                Assert.AreEqual(url1,url2, $"2) link '{url1}' must be navigated to");
                //searchBox.SendKeys("test");
                //var searchButton = driver.FindElementById("search_button");
                //searchButton.Submit();
                //var searchResults = driver.FindElementById("search_button");
                SeleniumTestHelpLibrary.TakeScreenshot(driver, subfolder, testName);
            }
        }
    }

    public class TestGeo
    {
        protected string www = @"https://geoforum.pl";
        protected string testName = "";
        protected string subfolder = DateTime.Now.ToShortDateString().Replace(":", "_");
        protected ChromeOptions options = SeleniumTestHelpLibrary.GetChromeOptions();
    }
}
