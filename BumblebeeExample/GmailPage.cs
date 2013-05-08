using System.Collections.Generic;
using System.Linq;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class GmailPage : WebBlock
    {
        public GmailPage(Session session) : base(session)
        {
        }

        public IEnumerable<InboxRow> InboxRows
        {
            get { return GetElements(By.ClassName("zA")).Select(tr => new InboxRow(Session, tr)); }
        }
    }
}
