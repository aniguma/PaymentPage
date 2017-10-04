using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Page = PaymentPage.PaymentPageApp.PaymentPage;

namespace Tests
{
    [TestClass]
    public static class Config
    {
        public static Page Page;

        [AssemblyInitialize]
        public static void Gou(TestContext testContext)
        {
            if (testContext == null)
            {
                throw new ArgumentNullException(nameof(testContext));
            }

            Page = new Page();
        }

        [AssemblyCleanup]
        public static void Ou()
        {
            Page.Dispose();
        }
    }

	public class TestBase
	{
	    /// <summary>
	    /// Represents root payment page
	    /// </summary>
	    protected Page Page => Config.Page;

		/// <summary>
		/// Run before every test
		/// </summary>
		[TestInitialize]
		public void SetUp()
		{
			Page.Initialize();
		}
    }
}