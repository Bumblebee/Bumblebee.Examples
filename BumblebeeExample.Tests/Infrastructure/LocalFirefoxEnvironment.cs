using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BumblebeeExample.Tests.Infrastructure
{
    public class LocalFirefoxEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(2000));
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
