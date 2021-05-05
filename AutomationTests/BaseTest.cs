using System;
using ApplicationFramework;
using AutomationFramework.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SettingManager;

namespace AutomationTests
{
    public class BaseTest
    {
        protected IWebDriver Driver => DriverProvider.GetDriver();
        protected IWait<IWebDriver> FluentWait = FluentWaitProvider.FluentWait;
        protected ApplicationPages Pages => new ApplicationPages();

        
        
        
        [SetUp]
        public void SetUp()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(ApplicationSettings.Url);

            
        }
        
        [TearDown]
        public void TearDown()
        {
            AddCurrentPageScreenshot();
        }

        protected void AddCurrentPageScreenshot()
        {
            var resultsFileName = $"{TestContext.CurrentContext.Test.MethodName}-{DateTime.UtcNow.ToString("yyyy_MM_dd-HH_mm_ss_ffff")}";
            var pathWithFileNameAndExtension = ApplicationSettings.ReportDirectoryPath + TestContext.CurrentContext.Test.Name + resultsFileName + ".jpg";

            var ss = ((ITakesScreenshot)Driver).GetScreenshot();
            ss.SaveAsFile(pathWithFileNameAndExtension);
            TestContext.AddTestAttachment(pathWithFileNameAndExtension);
        }
    }
}
