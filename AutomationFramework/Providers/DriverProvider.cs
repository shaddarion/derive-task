using AutomationFramework.CustomExceptions;
using OpenQA.Selenium;

namespace AutomationFramework.Providers
{
    public class DriverProvider
    {
        private static IWebDriver Driver { get; set; }

        public static IWebDriver GetDriver()
        {
            return Driver;
        }

        public static void SetDriver(IWebDriver driver)
        {
            Driver = driver ?? throw new NullWebDriverException("Driver is null, please make sure driver initialization works fine.");
        }
    }
}
