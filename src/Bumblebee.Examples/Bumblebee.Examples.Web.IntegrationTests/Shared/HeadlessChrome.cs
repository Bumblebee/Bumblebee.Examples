using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bumblebee.Examples.Web.IntegrationTests.Shared
{
    public class HeadlessChrome : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--enable-automation");
            options.AddArguments("--disable-gpu");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--silent");
            options.AddArgument("--log-level=3");

            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            return driver;
        }
    }
}
