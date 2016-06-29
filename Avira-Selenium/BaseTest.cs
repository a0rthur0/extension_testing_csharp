using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AviraSelenium
{
	public class BaseTest
	{
		protected IWebDriver _driver;
		public BaseTest ()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArguments("load-extension=/home/arthur/.config/google-chrome/Default/Extensions/flliilndjeohchalpbbcdekjklbdgfkk/1.10.1_0");
			_driver = new ChromeDriver(options);
		}
	}
}

