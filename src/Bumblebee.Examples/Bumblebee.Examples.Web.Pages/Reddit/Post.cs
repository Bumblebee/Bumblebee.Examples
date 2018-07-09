using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
    //public class Post : SpecificBlock
    //public class Post : WebBlock
    public class Post : Block
    {
        //public Post(Session session, IWebElement tag) : base(session, tag)
        public Post(IBlock parent, By by) : base(parent, by)
        {
		}

        //public IClickable<WebBlock> Title => new Clickable<WebBlock>(this, By.CssSelector("a.title"));
        public IClickable<Block> Title => new Clickable<Block>(this, By.CssSelector("a.title"));

        //public IClickable<WebBlock> Author => new Clickable<WebBlock>(this, By.ClassName("author"));
        public IClickable<Block> Author => new Clickable<Block>(this, By.ClassName("author"));

        //public IClickable<WebBlock> Comments => new Clickable<WebBlock>(this, By.ClassName("comments"));
        public IClickable<Block> Comments => new Clickable<Block>(this, By.ClassName("comments"));

        //public IClickable<WebBlock> Domain => new Clickable<WebBlock>(this, By.ClassName("domain"));
        public IClickable<Block> Domain => new Clickable<Block>(this, By.ClassName("domain"));

        public IClickable<RedditPage> Subreddit => new Clickable<RedditPage>(this, By.ClassName("subreddit"));

	    public string Rank => FindElement(By.ClassName("rank")).Text;
	}
}
