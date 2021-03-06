﻿using System;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BumblebeeExample.Tests.Infrastructure
{
    public class LocalChromeEnvironment : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new ChromeDriver(@"C:\SeGrid");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            return driver;
        }
    }
}
