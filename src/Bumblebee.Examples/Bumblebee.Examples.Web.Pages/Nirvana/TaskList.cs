using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    //5:  Get rid of SpecificBlock and just derive from WebBlock.
    //public class TaskList : SpecificBlock
    public class TaskList : WebBlock
	{
        public TaskList(IBlock parent, By by) : base(parent, by)
		//public TaskList(Session session, IWebElement tag) : base(session, tag)
		{
		}

		public string Name => FindElement(By.CssSelector(".name > .toggle")).Text.Trim();

	    public IEnumerable<TaskRow> TaskRows
		{
			get
			{
                //8:  Somtimes you need to use a more sophisticated CSS selector instead of a set of functions to return rich WebBlocks.
                /*return FindElement(By.ClassName("tasks"))
					.FindElements(By.ClassName("task"))
					.Select(tag => new TaskRow(Session, tag));*/

			    return new Blocks<TaskRow>(this, By.CssSelector(".tasks .task"));

			    /*return new Blocks<TaskRow>(this, By.Function(ctx => ctx.FindElements(By.ClassName("tasks"))
			            .SelectMany(x => x.FindElements(By.ClassName("task")))
			    ));*/
			}
		}
	}
}
