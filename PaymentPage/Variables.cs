using System;
using OpenQA.Selenium;

namespace PaymentPage
{
	public static class Variables
	{
		public const String ExpirationMonthDefault = "Month";
		public const String ExpirationYearDefault = "Year";
		public const String CardPrefix = "...";
		public const String CardDetailsTitle = "Cardpay Payment Page";
		public const String PaymentDetailsTitle = "Cardpay Result Page";
		public const String OrderNumber = "458211";
		public const String TotalAmount = "EUR   291.86";
		public const String SessionExpiredMessage = "Required parameters are omitted or the session has expired.";
		public const String PageUrl = "https://sandbox.cardpay.com/MI/cardpayment2.html?orderXml=PE9SREVSIFdBTExFVF9JRD0nODI5OScgT1JERVJfTlVNQkVSPSc0NTgyMTEnIEFNT1VOVD0nMjkxLjg2JyAgRU1BSUw9J2N1c3RvbWVyQGV4YW1wbGUuY29tJz4KPEFERFJFU1MgQ09VTlRSWT0nVVNBJyBTVEFURT0nTlknIFpJUD0nMTAwMDEnIENJVFk9J05ZJyBTVFJFRVQ9JzY3NyBTVFJFRVQnIFBIT05FPSc4NzY5OTA5MCcgVFlQRT0nQklMTElORycvPgo8L09SREVSPg==&sha512=529477e3f6966a47272add0ca4d552bc8e83f27c1682c87abfcb38caa026acb4d5bd3b97dfeee60b02407e85eaf62dbd0f4add7bbf74320bc26c4b9db56722ba";


		public static class Dropdown
		{
			public static readonly By ValuesSelector = By.CssSelector("option:not([data-i18n])");
			public static readonly By DefaultValueSelector = By.CssSelector("option[data-i18n]");
		}

		public static class CardDetails
		{
			public static readonly By CardNumberSelector = By.CssSelector("#input-card-number");
			public static readonly By CardholderNameSelector = By.CssSelector("#input-card-holder");
			public static readonly By ExpirationMonthSelector = By.CssSelector("#card-expires-month");
			public static readonly By ExpirationYearSelector = By.CssSelector("#card-expires-year");
			public static readonly By CvcSelector = By.CssSelector("#input-card-cvc");
			public static readonly By AcceptTermsSelector = By.CssSelector("#accept-terms-field");
			public static readonly By PrivacyPolicyModalSelector = By.CssSelector("#modal-privacy");
			public static readonly By PrivacyPolicyModalTitleSelector = By.CssSelector("h2[data-i18n*='modal.title']");
			public static readonly By PrivacyPolicyLinkSelector = By.CssSelector("#terms-tooltip");
			public static readonly By PayNowSelector = By.CssSelector("#action-submit");
			public static readonly By CancelSelector = By.CssSelector("#action-cancel");
		}

		public static class PaymentDetails
		{
			public static readonly By PaymentStatusSelector = By.CssSelector("#payment-item-status>.payment-info-item-data");
			public static readonly By OrderNumberSelector = By.CssSelector("#payment-item-ordernumber>.payment-info-item-data");
			public static readonly By AuthCodeSelector = By.CssSelector("#payment-item-authcode>.payment-info-item-data");
			public static readonly By CardNumberSelector = By.CssSelector("#payment-item-cardnumber>.payment-info-item-data");
			public static readonly By CardTypeSelector = By.CssSelector("#payment-item-cardtype>.payment-info-item-data");
			public static readonly By CardholderSelector = By.CssSelector("#payment-item-cardholder>.payment-info-item-data");
			public static readonly By TotalAmountSelector = By.CssSelector("#payment-item-total>.payment-info-item-data");
			public static readonly By BackToShopSelector = By.CssSelector("#formSubmit");
			public static readonly By CommonLabelSelector = By.CssSelector(".payment-info-item-data");
		}

		public static class Pan
		{
		    public const String Confirmed3DSecure = "4000000000000002";
		    public const String Declined3DSecure = "5555555555554444";
		    public const String Pending3DSecure = "4000000000000044";
			public const String ConfirmedNon3DSecure = "4000000000000077";
			public const String DeclinedNon3DSecure = "5555555555554477";
			public const String PendingNon3DSecure = "4000000000000051";
		}

		public static class CardType
		{
			public const String Visa = "VISA";
			public const String Mastercard = "MASTERCARD";
		}

		public static class PaymentStatus
		{
			public const String Approved = "APPROVED";
			public const String Declined = "DECLINED";
			public const String Pending = "PENDING";
		}

		public static class Month
		{
			public const String Jan = "01";
			public const String Feb = "02";
			public const String Mar = "03";
			public const String Apr = "04";
			public const String May = "05";
			public const String Jun = "06";
			public const String Jul = "07";
			public const String Aug = "08";
			public const String Sep = "09";
			public const String Oct = "10";
			public const String Nov = "11";
			public const String Dec = "12";
		}
	}
}
