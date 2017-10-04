using System;
using OpenQA.Selenium;

namespace PaymentPage.UiElements
{
    public sealed class Modal
    {
        private readonly IWebElement element;

        public Modal(IWebElement element) => this.element = element ?? throw new ArgumentNullException(nameof(element));

        public Boolean Displayed => element.Displayed;

        public String Title => element.FindElement(Variables.CardDetails.PrivacyPolicyModalTitleSelector).Text;
    }
}
