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
            Session.CurrentBlock<RedditPage>()
                   .Posts.Skip(2).Take(5).Random().Title.Click();
        }
    }
}
