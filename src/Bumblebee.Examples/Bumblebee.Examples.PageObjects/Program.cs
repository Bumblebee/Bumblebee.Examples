using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace Bumblebee.Examples.PageObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://old.reddit.com/");
            var page = new RedditPage(driver);
            var numberOfPosts = page.Posts.Count();
            var title = page.Posts[0].Title.Text;
        }
    }

    public class RedditPage
    {
        private readonly IWebDriver _driver;

        //[FindsBy(How = How.CssSelector, Using = "#siteTable .link")]
        //public IList<Post> Posts;
        public IList<Post> Posts => _driver.FindElements(By.CssSelector("#siteTable .link")).Select(x => new Post(x)).ToList();
        
        public RedditPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }

    public class Post
    {
        public Post(IWebElement element)
        {
            PageFactory.InitElements(element, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a.title")]
        public IWebElement Title;

        [FindsBy(How = How.ClassName, Using = "author")]
        public IWebElement Author;

        [FindsBy(How = How.ClassName, Using = "comments")]
        public IWebElement Comments;

        [FindsBy(How = How.ClassName, Using = "domain")]
        public IWebElement Domain;

        [FindsBy(How = How.ClassName, Using = "subredditt")]
        public IWebElement Subreddit;
    }
}
