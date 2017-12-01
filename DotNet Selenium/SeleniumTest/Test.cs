namespace SeleniumTest
{

    using NUnit.Framework;

    using System.Drawing;
    using System;
    using Applitools;
    using Applitools.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Safari;
 

    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {

            var driver = new ChromeDriver();
            var eyes = new Eyes();
						
            eyes.ApiKey = "your-applitools-key";
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
