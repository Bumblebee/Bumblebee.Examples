using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Extensions;
using BumblebeeExample.MobilePages.HomeTabs;
using BumblebeeIOS;
using OpenQA.Selenium;

namespace BumblebeeExample.MobilePages.TabController
{
    public class FrontView : TabBarController
    {
        public FrontView(Session session) : base(session)
        {
        }

        public IClickable<SubredditView> SubredditTab
        {
            get { return new Clickable<SubredditView>(this, ByIOS.Name("Subreddit")); }
        }

        public IClickable<NewView> NewTab
        {
            get { return new Clickable<NewView>(this, ByIOS.Name("New")); }
        }

        public IClickable<SubredditView> SavedTab
        {
            get { return new Clickable<SubredditView>(this, ByIOS.Name("Saved")); }
        }

        public IClickable<SubredditView> HiddenTab
        {
            get { return new Clickable<SubredditView>(this, ByIOS.Name("Hidden")); }
        }

        public IEnumerable<PostCell> Posts
        {
            get 
            { 
                return GetElement(ByIOS.Name("Empty list"))
                                    .FindElements(ByIOS.Type("UIATableCell"))
                                    .Select(e => new PostCell(this, e)); 
            }
        }


        public class PostCell : Clickable<PostView>
        {
            public PostCell(IBlock parent, By @by) : base(parent, @by)
            {
            }

            public PostCell(IBlock parent, IWebElement element) : base(parent, element)
            {
            }

            public FrontView Delete()
            {
                Session.CurrentBlock<FrontView>()
                    .Drag(e => this).AndDrop(-50, 0)
                    .WaitUntil(view => view.GetElements(ByIOS.PartialName("Confirm Deletion")).Any())
                    .GetElement(ByIOS.PartialName("Confirm Deletion")).Click();
                return new FrontView(Session);
            }
        }
    }
}
