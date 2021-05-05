using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.Providers
{
    public class FluentWaitProvider
    {
        private static IWait<IWebDriver> _fluentWait;

        public static IWait<IWebDriver> FluentWait => _fluentWait ??= SetUpFluentWait(DriverProvider.GetDriver());

        static IWait<IWebDriver> SetUpFluentWait(IWebDriver driver)
        {
            _fluentWait = new WebDriverWait(driver, TimeSpan.FromSeconds(60))
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));

            return _fluentWait;
        }
    }
}
