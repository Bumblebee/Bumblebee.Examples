using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Content
{
    public class TablesPage : WebBlock
    {
        public TablesPage(Session session) : base(session)
        {
        }

        public ITable TableInAscendingOrder
        {
            get { return new Table(this, By.Id("inAscendingOrder")); }
        }

        public ITable TableInDescendingOrder
        {
            get { return new Table(this, By.Id("inDescendingOrder")); }
        }
    }
}
