using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class LoggedOutPage : WebBlock
	{
		public LoggedOutPage(Session session) : base(session)
		{
		}

		public ITextField<LoggedOutPage> Username => new TextField<LoggedOutPage>(this, By.Id("login-user"));

	    public ITextField<LoggedOutPage> Password => new TextField<LoggedOutPage>(this, By.Id("login-pass"));

	    public IClickable Login => new Clickable(this, By.Id("login-btn-submit"));

	    public IHasText Error => new TextField(this, By.ClassName("alert"));
	}
}
