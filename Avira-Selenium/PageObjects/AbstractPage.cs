using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using FluentAssertions;
using System.Threading;

namespace AviraSelenium
{
	public abstract class AbstractPage
	{
		[FindsBy(How = How.ClassName, Using = "big-title")]
		public IWebElement ExtensionTitleElement { get; set; }

		[FindsBy(How = How.ClassName, Using = "info-text")]
		public IWebElement ExtensionInfoElement { get; set; }

		public AbstractPage ()
		{
			
		}
		public void CheckExtensionText(string TitleText, string InfoText)
		{
			ExtensionTitleElement.Displayed.Should ().BeTrue ();
			ExtensionTitleElement.Text.Should().Be(TitleText);
			ExtensionInfoElement.Displayed.Should ().BeTrue ();
			ExtensionInfoElement.Text.Should ().Contain (InfoText);
			System.Diagnostics.Debug.WriteLine (ExtensionTitleElement.Text);
		}
	}
}

