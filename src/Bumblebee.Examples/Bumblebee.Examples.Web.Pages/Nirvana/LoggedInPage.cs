using System;
using Bumblebee.Implementation;
using Bumblebee.Setup;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    //*Pages now replace the WebBlock and WebPage - support Wait
    //public class LoggedInPage : WebBlock
    //public class LoggedInPage : WebPage
    public class LoggedInPage : Page
    {
        public LoggedInPage(Session session) : base(session)
        //public LoggedInPage(IBlock parent) : base(parent, By.TagName("body"))
		{
            Wait.Until(driver => driver.FindElement(By.Id("north")));
		    //Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        //public ToolBar ToolBar => new ToolBar(Session);
	    public ToolBar ToolBar => new ToolBar(this);

        //public SideBar SideBar => new SideBar(Session);
	    public SideBar SideBar => new SideBar(this);

        //public MainArea MainArea => new MainArea(Session);
        public MainArea MainArea => new MainArea(this);
        
        //need to add reference on the page to this block for FindRelated to find it.
        public NewTaskForm NewTaskForm => new NewTaskForm(this);
    }
}
