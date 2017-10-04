using System;
using System.Linq;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Dropdown
    {
        private readonly IWebElement element;

        public Dropdown(IWebElement element) =>
            this.element = element ?? throw new ArgumentNullException(nameof(element));

        public String DefaultValue => element.FindElement(Variables.Dropdown.DefaultValueSelector).Text;

        public void SelectValue(String value)
        {
            element.Click();
            var values = element.FindElements(Variables.Dropdown.ValuesSelector);
            var elementToBeSelected = values.First(t => t.Text == value);
            elementToBeSelected.Click();
        }
    }
}
