using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class InboxRow : SpecificBlock
    {
        public InboxRow(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public bool Unread
        {
            get { return Tag.HasClass("zE"); }
        }

        public string From
        {
            get { return GetElement(By.ClassName("yX")).Text; }
        }

        public string Subject
        {
            get { return GetElement(By.ClassName("y6")).Text; }
        }

        public string Time
        {
            get { return GetElement(By.ClassName("xW")).Text; }
        }

        public ICheckbox<InboxRow> Checkbox
        {
            get { return new AriaCheckbox<InboxRow>(this, GetElement(By.CssSelector("div[role='checkbox']"))); }
        }

        public IClickable Link
        {
            get { return new Clickable(this, Tag);}
        }
    }
}
