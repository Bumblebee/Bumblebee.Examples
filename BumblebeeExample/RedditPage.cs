using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public IEnumerable<IClickable<RedditPage>> FeaturedSubreddits
        {
            get
            {
                return GetElements(By.CssSelector("#sr-bar a"))
                    .Where(a => a.Displayed)
                    .Select(a => new Clickable<RedditPage>(this, a));
            }
        }
    }
}
