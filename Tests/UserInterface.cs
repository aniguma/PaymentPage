using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentPage;
using PaymentPage.PaymentPageApp;

namespace Tests
{
	[TestClass]
	public class UserInterface : TestBase
	{
		private const String CardholderName = "Andrew Park";
		private const String Year = "2022";
		private const String Cvc = "011";

		[TestMethod]
		public void VerifyCardDetailsPage()
		{
			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.CardNumber), "Card number inputbox is not present");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardNumber.Value, "Card number inputbox is not empty");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.CardholderName), "Cardholder name inputbox is not present");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardholderName.Value, "Cardholder name inputbox is not empty");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.ExpirationMonth), "Expiration month dropdown is not present");
			Assert.AreEqual(Variables.ExpirationMonthDefault, Page.CardDetails.ExpirationMonth.DefaultValue, "Expiration month default value is not equal to expected");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.ExpirationYear), "Expiration year dropdown is not present");
			Assert.AreEqual(Variables.ExpirationYearDefault, Page.CardDetails.ExpirationYear.DefaultValue, "Expiration year default value is not equal to expected");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.CardCvc), "Card CVC inputbox is not present");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardCvc.Value, "Card CVC inputbox is not empty");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.AcceptTerms), "Accept terms checkbox is not present");
			Assert.IsFalse(Page.CardDetails.AcceptTerms.Checked, "Accept terms checkbox is checked by default");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.PayNow), "Pay Now button is not present");
			Assert.IsTrue(Page.CardDetails.PayNow.Enabled, "Pay Now button is not enabled by default");

			Assert.IsTrue(PaymentPage.PaymentPageApp.CardDetails.HasElement(Page.CardDetails.Cancel), "Cancel button is not present");
			Assert.IsTrue(Page.CardDetails.Cancel.Enabled, "Cancel button is not enabled by default");
		}

		[TestMethod]
		public void VerifyCardDetailsAreResetOnClickingCancel()
		{
			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Pending3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Feb);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();

			Page.CardDetails.Cancel.Click();

			Assert.AreEqual(Variables.CardDetailsTitle, Page.CardDetails.Title, "Page title is not equal to expected");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardNumber.Value, "Card number inputbox is not empty");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardholderName.Value, "Cardholder name inputbox is not empty");
			Assert.AreEqual(Variables.ExpirationMonthDefault, Page.CardDetails.ExpirationMonth.DefaultValue, "Expiration month default value is not equal to expected");
			Assert.AreEqual(Variables.ExpirationYearDefault, Page.CardDetails.ExpirationYear.DefaultValue, "Expiration year default value is not equal to expected");
			Assert.AreEqual(String.Empty, Page.CardDetails.CardCvc.Value, "Card CVC inputbox is not empty");
			Assert.IsFalse(Page.CardDetails.AcceptTerms.Checked, "Accept terms checkbox is checked by default");
			Assert.IsTrue(Page.CardDetails.PayNow.Enabled, "Pay Now button is not enabled by default");
			Assert.IsTrue(Page.CardDetails.Cancel.Enabled, "Cancel button is not enabled by default");
		}

		[TestMethod]
		public void VerifyCannotPayWhenRequiredFieldIsEmpty()
		{
			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Pending3DSecure);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Feb);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();

			Page.CardDetails.PayNow.Click();
			Assert.AreEqual(Variables.CardDetailsTitle, Page.CardDetails.Title, "Page title is not equal to expected");
		}

		[TestMethod]
		public void VerifyCannotPayWhenRequiredFieldIsIncorrect()
		{
			const String incorrectCardNumber = "123";

			Page.CardDetails.CardNumber.SetValue(incorrectCardNumber);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Apr);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();

			Page.CardDetails.PayNow.Click();
			Assert.AreEqual(Variables.CardDetailsTitle, Page.CardDetails.Title, "Page title is not equal to expected");
		}

		[TestMethod]
		public void VerifyPaymentDetailsPage()
		{
			Page.CardDetails.CardNumber.SetValue(Variables.Pan.Confirmed3DSecure);
			Page.CardDetails.CardholderName.SetValue(CardholderName);
			Page.CardDetails.ExpirationMonth.SelectValue(Variables.Month.Jan);
			Page.CardDetails.ExpirationYear.SelectValue(Year);
			Page.CardDetails.CardCvc.SetValue(Cvc);
			Page.CardDetails.AcceptTerms.Check();
			Page.CardDetails.PayNow.Click();

			Page.WaitPaymentResult();

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.PaymentStatus), "Payment status label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.PaymentStatus.Value, "Payment status label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.OrderNumber), "Order number label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.OrderNumber.Value, "Order number label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.AuthCode), "Auth code label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.AuthCode.Value, "Auth code label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.CardNumber), "Card number label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.CardNumber.Value, "Card number label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.CardType), "Card type label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.CardType.Value, "Card type label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.Cardholder), "Cardholder label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.Cardholder.Value, "Cardholder label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.TotalAmount), "Total amount label is not present");
			Assert.AreNotEqual(String.Empty, Page.PaymentDetails.TotalAmount.Value, "Total amount label is empty");

			Assert.IsTrue(PaymentDetails.HasElement(Page.PaymentDetails.BackToShop), "Back to the shop button is not present");
			Assert.IsTrue(Page.PaymentDetails.BackToShop.Enabled, "Back to the shop button is not enabled");
		}

		[TestMethod]
		public void VerifyPrivacyPolicyIsOpened()
		{
			const String title = "Privacy policy";

			Page.CardDetails.PrivacyPolicyLink.Click();
			Assert.IsTrue(Page.CardDetails.PrivacyPolicyModal.Displayed);
			Assert.AreEqual(title, Page.CardDetails.PrivacyPolicyModal.Title);
		}
	}
}
