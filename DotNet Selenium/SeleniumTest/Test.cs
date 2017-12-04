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
    using OpenQA.Selenium;

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
            eyes.MatchTimeout = TimeSpan.FromSeconds(5);

            try
            {
                driver.Navigate().GoToUrl("http://applitools.com");

                eyes.Open(driver, "www.applitools.com", "Home", new Size(1300, 750));

                //home page
                eyes.CheckWindow("Home");

                //features page
                driver.FindElement(By.PartialLinkText("Features")).Click();
                eyes.CheckWindow(TimeSpan.FromSeconds(5), "Features");
                eyes.CheckRegion(By.CssSelector("div.panel.unpadded.welcome-message"), TimeSpan.FromSeconds(5), "Welcome Message");

                //signup page
                driver.FindElement(By.CssSelector("a.btn.btn-call-to-action")).Click();
                eyes.Check("Sign Up", Applitools.Selenium.Target.Window().Fully().Timeout(TimeSpan.FromSeconds(5)));
                //Ignore(By.CssSelector("button.btn.btn-call-to-action")

                TestResults testResults = eyes.Close(false);
                Assert.IsTrue(testResults.IsPassed); 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                driver.Close();
                eyes.AbortIfNotClosed();
            }
        }
    }
}