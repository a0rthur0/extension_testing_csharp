using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using System.Threading;

namespace AviraSelenium.PageObjects
{
	public class WarningPage
	{
		private readonly IWebDriver _driver;

		public WarningPage (IWebDriver driver)
		{
			_driver = driver;
			PageFactory.InitElements(_driver, this);
		}
		[FindsBy(How = How.ClassName, Using = "blocked-page")]
		public IWebElement BlockedPage { get; set; }
		[FindsBy(How = How.ClassName, Using = "drop")]
		public IWebElement DropDownMoreButton { get; set; }
		[FindsBy(How = How.ClassName, Using = "check")]
		public IWebElement ExceptionCheckButton { get; set; }
		[FindsBy(How = How.Id, Using = "btn-add-exception")]
		public IWebElement ContinueButton { get; set; }

		public void CheckWarningStub()
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
			wait.Until (ExpectedConditions.ElementExists (By.ClassName (BlockedPage.GetAttribute ("class"))));
			string CurrentUrl = _driver.Url;
			if (!CurrentUrl.Contains ("chrome-extension"))
				_driver.Navigate().Refresh ();
		}

		public void AddExceptionForWebsite()
		{
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
			wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(DropDownMoreButton.GetAttribute("class"))));
			DropDownMoreButton.Click ();
			ExceptionCheckButton.Click ();
			ExceptionCheckButton.Text.ShouldBeEquivalentTo ("Added");
			ContinueButton.Click ();
		}
	}
}

