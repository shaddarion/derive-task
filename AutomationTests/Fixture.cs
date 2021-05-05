using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AutomationFramework.Providers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SettingManager;

namespace AutomationTests
{
    [SetUpFixture]
    public class Fixture
    {
        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            ReadSettings();

            var browser = ApplicationSettings.Browser;

            switch (browser)
            {
                case "chrome":
                    DriverProvider.SetDriver(InitializeChromeDriver());
                    break;
                case "firefox":
                    throw new NotImplementedException();
            }
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            DriverProvider.GetDriver()?.Quit();
            CloseWebDriverInstances();
        }

        private void ReadSettings()
        {
            ApplicationSettings.Url = TryParseTestContext("url", string.Empty);
            ApplicationSettings.Browser = TryParseTestContext("browser", string.Empty);
            ApplicationSettings.Headless = TryParseTestContext("headless", false);
            ApplicationSettings.PageLoadTime = TryParseTestContext("pageLoadTime", 0);
            ApplicationSettings.DefaultWaitTime = TryParseTestContext("defaultWaitTime", 0);
        }

        private IWebDriver InitializeChromeDriver()
        {
            var chromeOptions = new ChromeOptions();

            if (ApplicationSettings.Headless)
                chromeOptions.AddArguments("headless");

            chromeOptions.AddArguments("--window-size=1920,1080");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(assemblyPath, chromeOptions);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(ApplicationSettings.PageLoadTime);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ApplicationSettings.DefaultWaitTime);

            return driver;
        }

        private T TryParseTestContext<T>(string setting, T defaultValue)
        {
            var value = TestContext.Parameters[setting];

            return value == null ? defaultValue : (T)Convert.ChangeType(value, typeof(T));
        }

        private void CloseWebDriverInstances()
        {
            var AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                var s = process.ProcessName.ToLower();
                if (s.Equals("chromedriver"))
                    process.Kill();
            }
        }
    }
}
