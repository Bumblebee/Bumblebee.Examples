using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Tag = GetElement(By.Id("siteTable"));
        }

        public IEnumerable<Post> Posts
        {
            get { return GetElements(By.ClassName("entry")).Select(tag => new Post(Session, tag)); }
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
