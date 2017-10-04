using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentPage;

namespace Tests
{
	[TestClass]
	public class Security : TestBase
	{
		private const String CardholderName = "Jane Smith";
		private const String Year = "2018";
		private const String Cvc = "123";

		[TestMethod]
		public void VerifyCannotPayWhenCardIsExpired()
		{
			const String year = "2017";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.ConfirmedNon3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Feb);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Assert.AreEqual(Variables.CardDetailsTitle, Page.CardDetails.Title, "Page title is not equal to expected");
		}

		[TestMethod]
		public void VerifyCannotInjectJavaScriptCodeToCardholderName()
		{
			const String code = "<script>alert('Injected!');</script>";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Confirmed3DSecure);
			Page.CardDetails.CardholderName.SetValue(code);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Nov);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Assert.AreEqual(Variables.CardDetailsTitle, Page.CardDetails.Title, "Page title is not equal to expected");
		}

		[TestMethod]
		public void VerifySessionIsExpiredOnRequestingPaymentDetailsAgain()
		{
			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Confirmed3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Mar);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentDetailsTitle, Page.PaymentDetails.Title, "Page title is not equal to expected");
			Assert.AreEqual(Variables.PaymentStatus.Approved, Page.PaymentDetails.PaymentStatus.Value);

			Page.RefreshPage();

			Assert.AreEqual(Variables.PaymentDetailsTitle, Page.PaymentDetails.Title, "Page title after refreshing is not equal to expected");
			Assert.AreEqual(Variables.SessionExpiredMessage, Page.PaymentDetails.PaymentStatus.Value);
		}
	}
}
