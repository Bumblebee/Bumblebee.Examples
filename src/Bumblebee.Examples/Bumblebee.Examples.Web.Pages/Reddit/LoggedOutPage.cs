using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class LoggedOutPage : RedditPage
	{
		public LoggedOutPage(Session session) : base(session)
		{
		}

		public LoginArea LoginArea
		{
            //4:  Part of setting up a WebBlock-derived type - you pass the parent tag and not the Session.
			//get { return new LoginArea(Session); }
            get { return new LoginArea(this);}
		}
	}

	public class LoginArea : WebBlock
	{
        //4:  WebBlocks capture the expression for finding the Element in the constructor rather than setting it in a constructor.
		//public LoginArea(Session session) : base(session)
		public LoginArea(IBlock parent) : base(parent, By.Id("login_login-main"))
	    {
			//Tag = FindElement(By.Id("login_login-main"));
		}

		public ITextField<LoginArea> Email => new TextField<LoginArea>(this, By.Name("user"));

	    public ITextField<LoginArea> Password => new TextField<LoginArea>(this, By.Name("passwd"));

	    public IClickable<LoggedInPage> LoginButton => new Clickable<LoggedInPage>(this, By.TagName("button"));
	}
}
