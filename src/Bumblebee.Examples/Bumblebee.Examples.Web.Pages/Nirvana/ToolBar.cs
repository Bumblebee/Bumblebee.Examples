using System;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    //public class ToolBar : WebBlock
    public class ToolBar : Block
    {
        //public ToolBar(Session session) : base(session)
	    public ToolBar(IBlock parent) : base(parent, By.Id("north"), TimeSpan.FromSeconds(5))
        {
			//Tag = FindElement(By.Id("north"));
		}

		public ITextField<ToolBar> SearchField => new TextField<ToolBar>(this, By.ClassName("q"));

	    public IClickable<NewTaskForm> NewTask => new Clickable<NewTaskForm>(this, By.ClassName("newtask"));

	    public IHasText Account => new TextField(this, By.CssSelector("a.right.button.accountmenu.xcmenu"));
	}
}
