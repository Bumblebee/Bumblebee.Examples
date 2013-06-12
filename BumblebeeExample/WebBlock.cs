using System;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BumblebeeExample
{
    public class WebBlock : Block
    {
        protected WebDriverWait Wait { get; private set; }

        public WebBlock(Session session) : base(session)
        {
            this.Pause(500);
            Wait = new WebDriverWait(Session.Driver, new TimeSpan(3000));
            Tag = Wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}
