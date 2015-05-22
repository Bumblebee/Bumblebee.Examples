using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Extensions;
using BumblebeeExample.MobilePages.TabController;
using BumblebeeExample.Tests.MobileTests.Attributes;
using MbUnit.Framework;

namespace BumblebeeExample.Tests.MobileTests
{
    public class LoggedInTestSuite : MobileTestSuite
    {
        public override void Initialize()
        {
            base.Initialize();

            Session.CurrentBlock<FrontView>()
                   .Tabs.SettingsTab.Click()
                   .UsernameField.EnterText("Bumblebee_Example")
                   .PasswordField.EnterText("123abc!!")
                   .LogIn().Tabs.PostsTab.Click();
        }

        [Test]
        public void NavigateTabController()
        {
            Session.CurrentBlock<FrontView>()
                   .Tabs.SettingsTab.Click()
                   .Tabs.MessagesTab.Click()
                   .Tabs.PostsTab.Click()
                   .Tabs.MessagesTab.Click()
                   .Tabs.SettingsTab.Click()
                   .Tabs.PostsTab.Click();
        }
    }
}
