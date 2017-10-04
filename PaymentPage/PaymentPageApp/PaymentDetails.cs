using System;
using OpenQA.Selenium;
using PaymentPage.UiElements;

namespace PaymentPage.PaymentPageApp
{
	public sealed class PaymentDetails
	{
		private readonly IWebDriver driver;

		public PaymentDetails(IWebDriver driver) => this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

	    /// <summary>
		/// Represents Payment status label
		/// </summary>
		public Label PaymentStatus
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.PaymentStatusSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Order number label
		/// </summary>
		public Label OrderNumber
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.OrderNumberSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Authorization code label
		/// </summary>
		public Label AuthCode
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.AuthCodeSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Card number label
		/// </summary>
		public Label CardNumber
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.CardNumberSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Card type label
		/// </summary>
		public Label CardType
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.CardTypeSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Card holder label
		/// </summary>
		public Label Cardholder
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.CardholderSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Total amount label
		/// </summary>
		public Label TotalAmount
		{
			get
			{
				try
				{
					return new Label(driver.FindPaymentPageElement(Variables.PaymentDetails.TotalAmountSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Back to shop button
		/// </summary>
		public Button BackToShop
		{
			get
			{
				try
				{
					return new Button(driver.FindPaymentPageElement(Variables.PaymentDetails.BackToShopSelector));
				}
				catch (Exception)
				{
				    return null;
				}
			}
		}

		/// <summary>
		/// Represents Payment Details page title
		/// </summary>
		public String Title => driver.Title ?? String.Empty;

	    /// <summary>
        /// Indicates whether specified element is present in Payment Details page or not
        /// </summary>
        /// <param name="element">Element to find.</param>
        public static Boolean HasElement<T>(T element) => element != null;
	}
}
