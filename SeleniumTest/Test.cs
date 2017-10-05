using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Applitools.Selenium;
using System.Drawing;
using System;
using OpenQA.Selenium;
using Applitools;

namespace SeleniumTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var driver = new ChromeDriver();
			var eyes = new Eyes();
			eyes.ApiKey = "9RkMajXrzS1Zu110oTWQps102CHiPRPmeyND99E9iL0G7yAc110";
            eyes.ForceFullPageScreenshot = true;
            eyes.StitchMode = StitchModes.CSS;

            try
            {
                driver.Navigate().GoToUrl("http://applitools.com");

                eyes.Open(driver, "www.applitools.com", "Home", new Size(1006, 677));

				eyes.CheckWindow("Home");

				driver.FindElement(OpenQA.Selenium.By.PartialLinkText("Features")).Click();
				eyes.CheckWindow(TimeSpan.FromSeconds(5), "Features");


                eyes.CheckRegion(OpenQA.Selenium.By.CssSelector("div.panel.unpadded.welcome-message"), "Feature Area");

				driver.FindElement(OpenQA.Selenium.By.CssSelector("a.btn.btn-call-to-action")).Click();
				
                eyes.CheckWindow("Sign Up");

                eyes.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {

                driver.Close();
            }
        }
    }
}
