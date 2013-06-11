using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class RedditPage : WebBlock
    {
        public RedditPage(Session session) : base(session)
        {
        }

        public IEnumerable<Post> Posts
        {
            get
            {
                return GetElements(By.CssSelector("#siteTable .entry")).Select(tag => new Post(Session, tag));
            }
        }

        public IClickable<RedditPage> Next
        {
            get { return new Clickable<RedditPage>(this, By.ClassName("next")); }
        }

        public IClickable<RedditPage> Prev
        {
            get { return new Clickable<RedditPage>(this, By.ClassName("prev")); }
        }
    }

    public class LoggedOutPage : RedditPage
    {
        public LoggedOutPage(Session session) : base(session)
        {
        }

        public IClickable<LoginOrRegisterPopover> LoginOrRegister
        {
            get { return new Clickable<LoginOrRegisterPopover>(this, By.CssSelector(".user a")); }
        }
    }

    public class LoggedInPage : RedditPage
    {
        public LoggedInPage(Session session) : base(session)
        {
        }

        public IClickable<WebBlock> Profile
        {
            get { return new Clickable<LoginOrRegisterPopover>(this, By.CssSelector(".user a")); }
        }
    }

    public class Post : SpecificBlock
    {
        public Post(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public IClickable<WebBlock> Title
        {
            get { return new Clickable<WebBlock>(this, By.CssSelector("a.title")); }
        }

        public IClickable<WebBlock> Author
        {
            get { return new Clickable<WebBlock>(this, By.ClassName("author")); }
        }

        public IClickable<RedditPage> Subreddit
        {
            get { return new Clickable<RedditPage>(this, By.ClassName("subreddit")); }
        }

        public IClickable<WebBlock> Comments
        {
            get { return new Clickable<WebBlock>(this, By.ClassName("comments")); }
        }

        public IClickable<WebBlock> Domain
        {
            get { return new Clickable<WebBlock>(this, By.ClassName("domain")); }
        }
    }
}
