using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class NewTaskForm : WebBlock
	{
        //public NewTaskForm(Session session) : base(session)
	    public NewTaskForm(IBlock parent) : base(parent, By.ClassName("edit"))
        {
			//Tag = FindElement(By.ClassName("edit"));
		}

		public ITextField<NewTaskForm> Name => new TextField<NewTaskForm>(this, By.Name("name"));

	    public ITextField<NewTaskForm> Note => new TextField<NewTaskForm>(this, By.ClassName("note"));

	    public IClickable<MainArea> Save => new Clickable<MainArea>(this, By.ClassName("save"));

	    public IClickable<MainArea> Cancel => new Clickable<MainArea>(this, By.ClassName("cancel"));
	}
}
