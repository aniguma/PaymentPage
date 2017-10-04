using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentPage;
using PaymentPage.PaymentPageApp;

namespace Tests
{
	[TestClass]
	public class Processing : TestBase
	{
		private const String CardholderName = "Jane Smith";
		private const String Cvc = "123";
		private Int32 cardNumberLastDigits;

		[TestMethod]
		public void VerifyPaymentWith3DSecureIsApproved()
		{
			const String year = "2018";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Confirmed3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Feb);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Approved, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.AreEqual(6, Page.PaymentDetails.AuthCode.Value.Length);
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Visa, Page.PaymentDetails.CardType.Value);
		    Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
            Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPaymentWith3DSecureIsDeclined()
		{
			const String year = "2019";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Declined3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Oct);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Declined, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.IsFalse(PaymentDetails.HasElement(Page.PaymentDetails.AuthCode));
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Mastercard, Page.PaymentDetails.CardType.Value);
		    Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
            Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPaymentWith3DSecureIsPending()
		{
			const String year = "2021";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Pending3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Aug);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Pending, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.AreEqual(6, Page.PaymentDetails.AuthCode.Value.Length);
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Visa, Page.PaymentDetails.CardType.Value);
		    Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
            Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPaymentNon3DSecureIsApproved()
		{
			const String year = "2022";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.ConfirmedNon3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Dec);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Approved, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.AreEqual(6, Page.PaymentDetails.AuthCode.Value.Length);
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Visa, Page.PaymentDetails.CardType.Value);
		    Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
            Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPaymentNon3DSecureIsDeclined()
		{
			const String year = "2018";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.DeclinedNon3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Mar);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Declined, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.IsFalse(PaymentDetails.HasElement(Page.PaymentDetails.AuthCode));
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Mastercard, Page.PaymentDetails.CardType.Value);
		    Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
            Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPaymentNon3DSecureIsPending()
		{
			const String year = "2024";

			Page.CardDetails.CardNumber.SetValue(Variables.Pan.PendingNon3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Jul);
			Page.CardDetails.ExpirationYear.SelectValue(year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.AreEqual(Variables.PaymentStatus.Pending, Page.PaymentDetails.PaymentStatus.Value);
			Assert.AreEqual(Variables.OrderNumber, Page.PaymentDetails.OrderNumber.Value);
			Assert.AreEqual(6, Page.PaymentDetails.AuthCode.Value.Length);
			Assert.AreEqual(Variables.CardPrefix, Page.PaymentDetails.CardNumber.Value.Substring(0, 3));
			Assert.IsTrue(Int32.TryParse(Page.PaymentDetails.CardNumber.Value.Substring(3, 4), out cardNumberLastDigits));
			Assert.AreEqual(Variables.CardType.Visa, Page.PaymentDetails.CardType.Value);
			Assert.AreEqual(CardholderName.ToUpper(), Page.PaymentDetails.Cardholder.Value);
			Assert.AreEqual(Variables.TotalAmount, Page.PaymentDetails.TotalAmount.Value);
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Displayed, "Back to shop button is not displayed");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to shop button is not enabled");
		}
	}
}
