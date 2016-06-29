using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using System.Threading;
using System.Diagnostics;

namespace AviraSelenium.PageObjects
{
	public class SafePage
	{
		private readonly IWebDriver _driver;

		public SafePage (IWebDriver driver)
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
		[FindsBy(How = How.ClassName, Using = "big-title")]
		public IWebElement ExtensionTitle { get; set; }

		[FindsBy(How = How.ClassName, Using = "info-text")]
		public IWebElement ExtensionInfo { get; set; }

		public void OpenSafeExtension()
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

		public void CheckExtensionText(string TitleText, string InfoText)
		{
			ExtensionTitle.Displayed.Should ().BeTrue ();
			ExtensionTitle.Text.Should().Be(TitleText);
			ExtensionInfo.Displayed.Should ().BeTrue ();
			ExtensionInfo.Text.Should ().Contain (InfoText);
			Debug.WriteLine (ExtensionTitle.Text.ToString ());
			Debug.WriteLine (ExtensionInfo.Text.ToString ());
		}

	}
}

/*
 * 		public void OpenSafeExtension()
		{
			_driver.SwitchTo ().Frame (AviraIframe);
			WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
			try {
				CloseWelcome.Click ();
			} catch (NoSuchElementException) {
			}
			AviraSmallBar.Displayed.Should ().BeTrue ();
			Actions action = new Actions (_driver);
			action.MoveToElement (AviraSmallBar).Perform ();
			wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(Indicator.GetAttribute("class"))));
			Indicator.Click ();
		}
*/