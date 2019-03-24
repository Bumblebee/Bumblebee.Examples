using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
	public class LoggedOutPage : RedditPage
	{
		public LoggedOutPage(Session session) : base(session)
		{
		}

		public LoginArea LoginArea => new LoginArea(this);
	}

    //public class LoginArea : WebBlock
    public class LoginArea : Block
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
