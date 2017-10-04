using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Hyperlink
    {
        private readonly IWebElement element;

        public Hyperlink(IWebElement element) =>
            this.element = element ?? throw new ArgumentNullException(nameof(element));

        public void Click() => element.Click();
    }
}
