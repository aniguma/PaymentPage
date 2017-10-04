using System;
using OpenQA.Selenium;
using PaymentPage.UiElements;

namespace PaymentPage.PaymentPageApp
{
	public sealed class CardDetails
	{
		private readonly IWebDriver driver;

		public CardDetails(IWebDriver driver) => this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

	    /// <summary>
		/// Represents Card number inputbox
		/// </summary>
		public Inputbox CardNumber
		{
			get
			{
				try
				{
					return new Inputbox(driver.FindPaymentPageElement(Variables.CardDetails.CardNumberSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Cardholder name inputbox
		/// </summary>
		public Inputbox CardholderName
		{
			get
			{
				try
				{
					return new Inputbox(driver.FindPaymentPageElement(Variables.CardDetails.CardholderNameSelector));
				}
                catch (Exception)
                {
                    return null;
                }
            }
		}

		/// <summary>
		/// Represents expiration month dropdown
		/// </summary>
		public Dropdown ExpirationMonth
		{
			get
			{
				try
				{
					return new Dropdown(driver.FindPaymentPageElement(Variables.CardDetails.ExpirationMonthSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents expiration year dropdown
		/// </summary>
		public Dropdown ExpirationYear
		{
			get
			{
				try
				{
					return new Dropdown(driver.FindPaymentPageElement(Variables.CardDetails.ExpirationYearSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents CVV2/CVC2 inputbox
		/// </summary>
		public Inputbox CardCvc
		{
			get
			{
				try
				{
					return new Inputbox(driver.FindPaymentPageElement(Variables.CardDetails.CvcSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents accept terms checkbox
		/// </summary>
		public Checkbox AcceptTerms
		{
			get
			{
				try
				{
					return new Checkbox(driver.FindPaymentPageElement(Variables.CardDetails.AcceptTermsSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Privacy Policy hyperlink
		/// </summary>
		public Hyperlink PrivacyPolicyLink
		{
			get
			{
				try
				{
					return new Hyperlink(driver.FindPaymentPageElement(Variables.CardDetails.PrivacyPolicyLinkSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Privacy Policy modal
		/// </summary>
		public Modal PrivacyPolicyModal
		{
			get
			{
				try
				{
					return new Modal(driver.FindPaymentPageElement(Variables.CardDetails.PrivacyPolicyModalSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Pay Now button
		/// </summary>
		public Button PayNow
		{
			get
			{
				try
				{
					return new Button(driver.FindPaymentPageElement(Variables.CardDetails.PayNowSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Cancel button
		/// </summary>
		public Button Cancel
		{
			get
			{
				try
				{
					return new Button(driver.FindPaymentPageElement(Variables.CardDetails.CancelSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Card Details page title
		/// </summary>
		public String Title => driver.Title ?? String.Empty;

        /// <summary>
        /// Indicates whether specified element is present in Card Details page or not
        /// </summary>
        /// <param name="element">Element to find.</param>
        public static Boolean HasElement<T>(T element) => element != null;
	}
}
