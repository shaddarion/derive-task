using System;
using System.Diagnostics;
using OpenQA.Selenium;

namespace AutomationFramework.ExtensionMethods
{
    public static class ElementExtensionMethods
    {
        public static void Ex_Click(this IWebElement element)
        {
            var message = string.Empty;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                if (stopwatch.ElapsedMilliseconds > 60 * 1000)
                {
                    throw new ElementClickInterceptedException($"It is impossible to click element by locator [{element}]. Message: {message}");
                }

                try
                {
                    element.Click();
                    break;
                }
                catch (ElementClickInterceptedException e)
                {
                    message = e.GetType().FullName + " - " + e.Message;
                }
                catch (ElementNotInteractableException e)
                {
                    message = e.GetType().FullName + " - " + e.Message;
                }
                catch (Exception e)
                {
                    message = e.GetType().FullName + " - " + e.Message;
                }
            }
        }
    }
}
