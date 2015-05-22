using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using BumblebeeIOS;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BumblebeeExample.MobilePages
{
    public class MobileBlock : IOSBlock
    {
        public MobileBlock(Session session) : base(session)
        {
            var wait = new WebDriverWait(Session.Driver, new TimeSpan(5000));
            Tag = wait.Until(driver => driver.GetElement(ByIOS.Type("UIAApplication")));
        }
    }
}
