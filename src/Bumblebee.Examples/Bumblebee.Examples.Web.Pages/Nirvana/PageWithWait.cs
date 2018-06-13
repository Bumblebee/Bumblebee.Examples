using System;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    public class PageWithWait : Page
    {
        public PageWithWait(Session session, TimeSpan timeout) : base(session)
        {
            this.Pause(200);
            this.Wait = new WebDriverWait(this.Session.Driver, timeout);
        }

        public PageWithWait(Session session) : this(session, TimeSpan.FromTicks(3000L))
        { }

        protected WebDriverWait Wait { get; private set; }

        public override IWebElement Tag
        {
            get
            {
                return this.Session.Driver.SwitchTo().DefaultContent().FindElement(this.Specification);
            }
        }
    }
}