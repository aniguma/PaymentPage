using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PaymentPage
{
    internal static class Extensions
    {
        private const Int32 SearchTimeout = 2;
        private const Int32 Timeout = 5;

        public static IWebElement FindPaymentPageElement(this IWebDriver driver, By by, Int32 timeout = SearchTimeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            var element = wait.Until(ExpectedConditions.ElementExists(by));

            if (element.Displayed) return element;

            wait.Until(d => element.Displayed);
            return element;
        }

        public static void WaitUntilElementIsDisplayed(this IWebDriver driver, By by, Int32 timeout = Timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new InvalidOperationException($"{by}. is not displayed in {timeout} second(s).");
            }
        }

        public static void WaitUntilTitleIs(this IWebDriver driver, String expectedTitle, Int32 timeout = Timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            try
            {
                wait.Until(ExpectedConditions.TitleIs(expectedTitle));
            }
            catch (WebDriverTimeoutException)
            {
                throw new InvalidOperationException($"Page title doesn't contain '{expectedTitle}' after waiting for {timeout} second(s). Actual title is '{driver.Title}'");
            }
        }
    }
}
