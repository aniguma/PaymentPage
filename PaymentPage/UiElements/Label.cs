using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Label
    {
        private readonly IWebElement element;

        public Label(IWebElement element) => this.element = element ?? throw new ArgumentNullException(nameof(element));

        public String Value => element.Text;
    }
}
