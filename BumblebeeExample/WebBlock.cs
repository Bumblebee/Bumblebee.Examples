using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BumblebeeExample
{
    public class WebBlock : Block
    {
        public WebBlock(Session session) : base(session)
        {
            var wait = new WebDriverWait(Session.Driver, new TimeSpan(5000));
            Tag = wait.Until(driver => driver.GetElement(By.TagName("body")));
        }
    }
}
