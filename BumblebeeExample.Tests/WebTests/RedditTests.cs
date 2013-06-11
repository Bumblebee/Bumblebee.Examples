using System.Linq;
using Bumblebee.Extensions;
using MbUnit.Framework;
using OpenQA.Selenium;
using TestSuite = BumblebeeExample.Tests.Infrastructure.TestSuite;

namespace BumblebeeExample.Tests.WebTests
{
    [Parallelizable]
    public class RedditTests : TestSuite
    {
        [SetUp]
        public void GoToReddit()
        {
            Session.NavigateTo<LoggedOutPage>("http://www.reddit.com");
        }

        [Test]
        public void Login()
        {
            Session.CurrentBlock<LoggedOutPage>()
                   .LoginArea
                   .Email.EnterText("bumblebeeexample")
                   .Password.EnterText("123abc!!")
                   .LoginButton.Click();
        }

        [Test]
        public void FailLogin()
        {
            Session.CurrentBlock<LoggedOutPage>()
                   .LoginArea
                   .Email.EnterText("zxcve")
                   .Password.EnterText("zxcvzxcv!!")
                   .LoginButton.Click<LoggedOutPage>()
                   .VerifyPresenceOf("the login area", By.Id("login_login-main"));
        }

        [Test]
        public void VerifyObviousThings()
        {
            Session.CurrentBlock<LoggedOutPage>()
                   .Verify("that there is at least one TIL on front page",
                           page => page.Posts.Any(post => post.Subreddit.Text == "todayilearned"))
                   .Verify("there are no selenium subreddit posts on front page",
                           page => page.Posts.All(post => post.Subreddit.Text != "selenium"));
        }

        [Test]
        public void ShowPostsFromRandomSubreddit()
        {
            string sub;
            Session.CurrentBlock<LoggedOutPage>()
                   .FeaturedSubreddits.Random()
                   .Store(out sub, rand => rand.Text)
                   .Click()
                   .DebugPrint(page => page.Posts.Select(post => post.Title.Text));
        }
    }
}
