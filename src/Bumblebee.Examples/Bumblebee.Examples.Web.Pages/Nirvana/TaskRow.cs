using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    //public class TaskRow : SpecificBlock
    //public class TaskRow : WebBlock
    public class TaskRow : Block
    {
        //public TaskRow(Session session, IWebElement tag) : base(session, tag)
        public TaskRow(IBlock parent, By by) : base(parent, by)
        {
		}

		public string Name => FindElement(By.CssSelector("span.name.edittask")).Text;

	    public IClickable<TaskRow> Complete => new Clickable<TaskRow>(this, By.CssSelector("span.i.check"));

	    public void Delete()
		{
			var drag = FindElement(By.CssSelector("span.i.drag.project"));

            //var drop = new SideBar(Session).Trash;
		    var trash = this.FindRelated<SideBar>().Trash;

            GetDragAndDropPerformer()
				.DragAndDrop(drag, trash);

			Session.Pause(200);
		}
	}
}
