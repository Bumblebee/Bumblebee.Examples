using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using BumblebeeExample.MobilePages.TabController;
using BumblebeeIOS;

namespace BumblebeeExample.MobilePages
{
    public class TabBarController : MobileBlock
    {
        public TabBarController(Session session) : base(session)
        {
        }

        public TabBar Tabs
        {
            get { return new TabBar(Session); }
        }

        public class TabBar : MobileBlock
        {
            public TabBar(Session session) : base(session)
            {
            }

            public IClickable<FrontView> PostsTab
            {
                get { return new Clickable<FrontView>(this, ByIOS.Name("Posts")); }
            }

            public IClickable<MessagesView> MessagesTab
            {
                get { return new Clickable<MessagesView>(this, ByIOS.Name("Messages")); }
            }

            public IClickable<SettingsView> SettingsTab
            {
                get { return new Clickable<SettingsView>(this, ByIOS.Name("Settings")); }
            }
        }
    }
}
