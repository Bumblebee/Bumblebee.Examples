using System.Collections.Generic;
using System.Linq;
using Bumblebee.Extensions;
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

        public LoginArea LoginArea
        {
            get { return new LoginArea(Session); }
        }
    }

    public class LoginArea : WebBlock
    {
        public LoginArea(Session session) : base(session)
        {
            Tag = GetElement(By.Id("login_login-main"));
        }

        public ITextField<LoginArea> Email
        {
            get { return new TextField<LoginArea>(this, By.Name("user")); }
        }

        public ITextField<LoginArea> Password
        {
            get { return new TextField<LoginArea>(this, By.Name("passwd")); }
        }

        public IClickable<LoggedInPage> LoginButton
        {
            get { return new Clickable<LoggedInPage>(this, By.TagName("button")); }
        }
    }

    public class LoggedInPage : RedditPage
    {
        public LoggedInPage(Session session) : base(session)
        {
            // Wait until we're logged in, then reselect the body to keep the DOM fresh
            Wait.Until(driver => driver.GetElement(By.CssSelector(".user a")));
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }

        public IClickable<WebBlock> Profile
        {
            get { return new Clickable<WebBlock>(this, By.CssSelector(".user a")); }
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
