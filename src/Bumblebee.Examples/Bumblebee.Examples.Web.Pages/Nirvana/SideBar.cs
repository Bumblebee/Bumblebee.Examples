using Bumblebee.Implementation;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
	public class SideBar : WebBlock
	{
		public SideBar(Session session) : base(session)
		{
			Tag = FindElement(By.Id("east"));
		}

		public IWebElement Trash => FindElement(By.ClassName("trash"));
	}
}
