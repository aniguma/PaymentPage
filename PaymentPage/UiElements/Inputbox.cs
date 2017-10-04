using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Inputbox
    {
        private readonly IWebElement element;

        public Inputbox(IWebElement element) =>
            this.element = element ?? throw new ArgumentNullException(nameof(element));

        public String Value => element.Text;

        public void SetValue(String value)
        {
            if (!element.Enabled) return;
            element.SendKeys(value);
            element.SendKeys(Keys.Enter);
        }
    }
}
