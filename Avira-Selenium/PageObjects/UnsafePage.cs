using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using System.Threading;


namespace AviraSelenium.PageObjects
{
	public class UnsafePage:AbstractPage
	{
		private readonly IWebDriver _driver;

		public UnsafePage (IWebDriver driver)
		{
			_driver = driver;
			PageFactory.InitElements(_driver, this);
		}

		[FindsBy(How = How.Id, Using = "abs-top-frame")]
		public IWebElement AviraIframe { get; set; }
		[FindsBy(How = How.ClassName, Using = "alien-placeholder")]
		public IWebElement AviraSmallBar { get; set; }
		[FindsBy(How = How.ClassName, Using = "tour-card-close")]
		public IWebElement CloseWelcome { get; set; }
		[FindsBy(How = How.ClassName, Using = "indicator-text")]
		public IWebElement Indicator { get; set; }


		public void OpenUnsafeExtension ()
		{
			_driver.SwitchTo ().Frame (AviraIframe);
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

			try {
				CloseWelcome.Click ();
			} catch (NoSuchElementException) {
			}

			Actions action = new Actions (_driver);
			wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(AviraSmallBar.GetAttribute("class"))));
			action.MoveToElement (AviraSmallBar).Perform ();
			wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(Indicator.GetAttribute ("class"))));
			Indicator.Click ();
		}



	}
}

