using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Button
    {
        private readonly IWebElement element;

        public Button(IWebElement element) =>
            this.element = element ?? throw new ArgumentNullException(nameof(element));

        public Boolean Displayed => element.Displayed;

        public Boolean Enabled => element.Enabled;

        public void Click() => element.Click();
    }
}
