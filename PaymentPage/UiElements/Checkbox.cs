using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Checkbox
    {
        private readonly IWebElement element;

        public Checkbox(IWebElement element) =>
            this.element = element ?? throw new ArgumentNullException(nameof(element));

        public Boolean Checked => element.Selected;

        public void Check() => element.Click();
    }
}
