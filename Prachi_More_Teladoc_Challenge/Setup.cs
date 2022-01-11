using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Prachi_More_Teladoc_Challenge
{
    [SetUpFixture]
    public class Setup
    {
        public static IWebDriver driver = new ChromeDriver(@"C:\Prachi_More_Teladoc_Challenge\Prachi_More_Teladoc_Challenge\Driver\v97.0");

        [OneTimeSetUp]
        public void Startup()
        {
            string url = "https://www.way2automation.com/angularjs-protractor/webtables";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);            
        }

        [OneTimeTearDown]
        public void Cleanup()

        {
            driver.Dispose();            
        }
    }
}
