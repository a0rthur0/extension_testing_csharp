using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using AviraSelenium.PageObjects;

namespace AviraSelenium.TestCases
{
	[TestFixture]
	public class TestUnsafe:BaseTest
	{

		string UnsafeUrl = "http://www.auc-test-category-phishing.com";

		[SetUp]
		public void TestSetup ()
		{
			_driver.Navigate ().GoToUrl (UnsafeUrl);
		}

		[TearDown]
		public void Cleanup ()
		{
			_driver.Quit ();
		}

		[Test]
		public void TestUnsafeWebsiteDetection ()
		{
			WarningPage warning = new WarningPage (_driver);
			warning.CheckWarningStub ();
			warning.AddExceptionForWebsite ();
			AviraExtension extension = new AviraExtension (_driver);
			extension.OpenExtension ();
			extension.CheckExtensionText("Unsafe Website","This website has been identified as a phishing site.");
		}
	}
}