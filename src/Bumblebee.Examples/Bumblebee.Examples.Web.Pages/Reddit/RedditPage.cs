using System.Collections.Generic;
using System.Linq;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;

namespace Bumblebee.Examples.Web.Pages.Reddit
{
    //1:  Pages need to derive from Page, not WebBlock to limit parameters and NavigateTo() method.
    //public class RedditPage : WebBlock
    //public class RedditPage : WebPage
    public class RedditPage : Page
    {
		public RedditPage(Session session) : base(session)
		{
		}

		public IEnumerable<Post> Posts
		{
			get
			{
				/*return FindElements(By.CssSelector("#siteTable .link"))
					.Select(tag => new Post(Session, tag));*/

			    return new Blocks<Post>(this, By.CssSelector("#siteTable .link"));
			}
		}

		public IEnumerable<Post> RankedPosts
		{
			get { return Posts.Where(post => post.Rank != string.Empty); }
		}

		public IClickable<RedditPage> Next => new Clickable<RedditPage>(this, By.CssSelector(".next-button a"));

	    public IClickable<RedditPage> Prev => new Clickable<RedditPage>(this, By.CssSelector(".prev-button a"));

	    public IEnumerable<IClickable<RedditPage>> FeaturedSubreddits
		{
			get
            {
                /*return FindElements(By.CssSelector("#sr-bar a"))
                    .Where(a => a.Displayed)
                    .Select(a => new Clickable<RedditPage>(this, a));*/
                
                //2:  Use By.Function() to encapsulate the logic to FindElements.
                //3:  Use Elements<T>(IBlock, By) to encapsulate logic for finding a list of Elements.

                return new Elements<Clickable<RedditPage>>(this, By.Function(ctx => 
                    ctx.FindElements(By.CssSelector("#sr-bar a"))
                        .Where(a => a.Displayed)));
            }
		}
	}
}
