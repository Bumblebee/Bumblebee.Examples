using System.Collections.Generic;
using System.Linq;

using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class TaskList : SpecificBlock
	{
		public TaskList(Session session, IWebElement tag) : base(session, tag)
		{
		}

		public string Name => FindElement(By.CssSelector(".name > .toggle")).Text.Trim();

	    public IEnumerable<TaskRow> TaskRows
		{
			get
			{
				return FindElement(By.ClassName("tasks"))
					.FindElements(By.ClassName("task"))
					.Select(tag => new TaskRow(Session, tag));
			}
		}
	}
}
