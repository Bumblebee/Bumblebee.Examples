using System;
using System.Linq;
using Bumblebee.Extensions;
using BumblebeeExample.MobilePages;
using BumblebeeIOS;
using BumblebeeIOS.Extensions;
using BumblebeeExample.MobilePages.TabController;
using BumblebeeIOS.UIAObjects;
using MbUnit.Framework;
using OpenQA.Selenium;

namespace BumblebeeExample.Tests.MobileTests
{
    public class RedditMobileTests : MobileTestSuite
    {
        [Test]
        public void TryToLogIn()
        {
            Session.CurrentBlock<FrontView>()
                   .Tabs.SettingsTab.Click()
                   .UsernameField.EnterText("BadLogin")
                   .PasswordField.EnterText("password1234")
                   .LogIn();
        }

        [Test]
        public void DeleteRandomPosts()
        {
            int numPosts;

            Session.CurrentBlock<FrontView>()
                   .Store(out numPosts, view => view.Posts.Count())
                   .Posts.Random().Delete()
                   .Posts.Random().Delete()
                   .Verify("Exactly 2 posts were deleted", view => numPosts - 2 == view.Posts.Count());
        }
    }
}
