﻿using System.Collections.Generic;
using System.Linq;

using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class MainArea : WebBlock
	{
	    public MainArea(IBlock parent) : base(parent, By.Id("main"))
        //public MainArea(Session session) : base(session)
        {
			//Tag = FindElement(By.Id("main"));
		}

		public IEnumerable<TaskList> TaskLists
		{
			get
			{
				/*return FindElements(By.ClassName("tasklist"))
					.Select(x => new TaskList(Session, x));*/
                
                //6:  Instead of returning a list of WebBlock-derived classes, you must create a new Block<T>.
			    return new Blocks<TaskList>(this, By.ClassName("tasklist"));
			}
		}
	}
}
