using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class LoggedInPage : RedditPage
    {
        public LoggedInPage(Session session) : base(session)
        {
            // Wait until we're logged in, then reselect the body to keep the DOM fresh
            Wait.Until(driver => driver.GetElement(By.CssSelector(".user a")));
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }

        public IClickable<WebBlock> Profile
        {
            get { return new Clickable<WebBlock>(this, By.CssSelector(".user a")); }
        }
    }
}