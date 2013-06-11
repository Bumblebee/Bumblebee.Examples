using System;
using System.Linq;
using Bumblebee.Extensions;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public class RedditTests : TestSuite
    {
        [Test]
        public void DoStuff()
        {
            Session.CurrentBlock<LoggedOutPage>()
                   .LoginOrRegister.Click()
                   .LoginForm
                   .Email.EnterText("bumblebeeexample")
                   .Password.EnterText("123abc!!")
                   .LoginButton.Click<LoggedInPage>()
                   .Posts.Skip(2).Take(5).Random().Title.Click();
        }
    }
}
