using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using AviraSelenium.PageObjects;

namespace AviraSelenium.TestCases
{
	[TestFixture]
	public class TestSafe:BaseTest
	{
		
		string SafeUrl = "http://www.auc-test-category-clean.com/";

		[SetUp]
		public void TestSetup ()
		{
			_driver.Navigate ().GoToUrl (SafeUrl);
		}

		[TearDown]
		public void Cleanup ()
		{
			_driver.Quit ();
		}

		[Test]
		public void TestSafeWebsiteDetection ()
		{
			AviraExtension extension = new AviraExtension (_driver);
			extension.OpenExtension ();
			extension.CheckExtensionText("Safe Website","No known threats");


		}
	}
}