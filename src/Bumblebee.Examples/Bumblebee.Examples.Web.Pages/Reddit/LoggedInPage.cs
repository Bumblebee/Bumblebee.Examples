using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class LoggedInPage : RedditPage
	{
		public LoggedInPage(Session session) : base(session)
		{
			// Wait until we're logged in, then reselect the body to keep the DOM fresh
			//Wait.Until(driver => driver.FindElement(By.CssSelector(".user a")));
			//Tag = Session.Driver.FindElement(By.TagName("body"));
		}

        //public IClickable<WebBlock> Profile => new Clickable<WebBlock>(this, By.CssSelector(".user a"));
	    public IClickable<Block> Profile => new Clickable<Block>(this, By.CssSelector(".user a"));

        public IClickable<LoggedOutPage> Logout => new Clickable<LoggedOutPage>(this, By.LinkText("logout"));
	}
}
