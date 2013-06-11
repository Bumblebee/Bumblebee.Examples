using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BumblebeeExample.MobilePages;
using BumblebeeExample.MobilePages.HomeTabs;
using BumblebeeExample.MobilePages.TabController;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public class RedditMobileTests : MobileTestSuite
    {
        [Test]
        public void Test()
        {
            Session.CurrentBlock<FrontView>()
                   .Tabs.SettingsTab.Click();
            Thread.Sleep(2000);
        }
    }
}
