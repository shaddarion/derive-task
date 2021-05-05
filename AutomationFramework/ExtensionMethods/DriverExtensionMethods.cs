using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationFramework.ExtensionMethods
{
    public static class DriverExtensionMethods
    {
        public static void Ex_HoverElement(this IWebDriver driver, IWebElement element)
        {
            if (element == null)
                throw new NullReferenceException("Element is null. Make sure element exists.");
            
            var action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
        }
    }
}
