using System;
using System.Linq;
using Bumblebee.Extensions;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public class RedditTests : TestSuite
    {
        [SetUp]
        public void GoToReddit()
        {
            Session.NavigateTo<LoggedOutPage>("http://www.reddit.com");
        }

        [Test]
        public void DoStuff()
        {
            Session.CurrentBlock<LoggedOutPage>()
                   .Verify("that there is at least one TIL on front page",
                           page => page.Posts.Any(post => post.Subreddit.Text == "todayilearned"))
                   .Verify("there are no sdlkf subreddits on front page",
                           page => page.Posts.All(post => post.Subreddit.Text != "selenium"))
                   .LoginArea
                   .Email.EnterText("bumblebeeexample")
                   .Password.EnterText("123abc!!")
                   .LoginButton.Click()
                   .Next.Click()
                   .Posts.Last(post => post.Title.Text.Contains("e"))
                   .Title.Click();
        }
    }
}
