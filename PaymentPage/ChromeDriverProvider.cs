using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PaymentPage
{
	public static class ChromeDriverProvider
	{
		private const Int32 Timeout = 5;

		public static IWebDriver GetInstance()
		{
			var options = new ChromeOptions();
			options.AddArguments("--start-maximized");
			var driver = new ChromeDriver(options);

			driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Timeout));
			return driver;
		}
	}
}
