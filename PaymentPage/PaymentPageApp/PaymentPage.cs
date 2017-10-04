using System;
using OpenQA.Selenium;

namespace PaymentPage.PaymentPageApp
{
    public sealed class PaymentPage : IDisposable
    {
        private readonly IWebDriver driver;

        public PaymentPage()
        {
            driver = ChromeDriverProvider.GetInstance();

            CardDetails = new CardDetails(driver);
            PaymentDetails = new PaymentDetails(driver);
        }

        /// <summary>
        /// Represents Card Details page
        /// </summary>
        public CardDetails CardDetails { get; private set; }

        /// <summary>
        /// Represents Payment Details page
        /// </summary>
        public PaymentDetails PaymentDetails { get; private set; }

        /// <summary>
        /// Dispose WebDriver
        /// </summary>
        public void Dispose() => driver.Quit();

        /// <summary>
        /// Navigate to Card Details page
        /// </summary>
        public void Initialize()
        {
            driver.Navigate().GoToUrl(Variables.PageUrl);
            driver.WaitUntilTitleIs(Variables.CardDetailsTitle);
            driver.WaitUntilElementIsDisplayed(Variables.CardDetails.CardNumberSelector);
        }

        /// <summary>
        /// Refresh the current page
        /// </summary>
        public void RefreshPage() => driver.Navigate().Refresh();

        /// <summary>
        /// Wait until processing operation is completed
        /// </summary>
        public void WaitPaymentResult()
        {
            driver.WaitUntilTitleIs(Variables.PaymentDetailsTitle);
            driver.WaitUntilElementIsDisplayed(Variables.PaymentDetails.CardNumberSelector);
        }
    }
}