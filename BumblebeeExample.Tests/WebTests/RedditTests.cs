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
                   .Email.EnterText("jjjjjjj")
                   .Password.EnterText("jjjjjjj")
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
            Session.CurrentBlock<LoggedOutPage>()
                   .FeaturedSubreddits.Take(5).Random().Click()
                   .DebugPrint(page => page.Posts.Select(post => post.Title.Text))
                   .Verify(page => page.Posts.First().Rank == "1")
                   .Next.Click()
                   .Verify(page => page.Posts.First().Rank == "26");
        }
    }
}
