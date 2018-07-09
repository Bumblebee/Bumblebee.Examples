using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Nirvana
{
    //public class SideBar : WebBlock
    public class SideBar : Block
    {
		//public SideBar(Session session) : base(session)
        public SideBar(IBlock parent) : base(parent, By.Id("east"))
		{
			//Tag = FindElement(By.Id("east"));
		}

		public IWebElement Trash => FindElement(By.ClassName("trash"));
	}
}
