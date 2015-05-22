using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bumblebee.Exceptions;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using Bumblebee.Extensions;
using BumblebeeIOS;
using BumblebeeIOS.Implementation;

namespace BumblebeeExample.MobilePages.TabController
{
    public class SettingsView : TabBarController
    {
        public SettingsView(Session session) : base(session)
        {
        }

        public ITextField<SettingsView> UsernameField
        {
            get { return new TextField<SettingsView>(this, GetElement(ByIOS.Name("Username"))
                                                             .FindElement(ByIOS.Type("UIATextField"))); }
        }

        public ITextField<SettingsView> PasswordField
        {
            get
            {
                return new TextField<SettingsView>(this, GetElement(ByIOS.Name("Password"))
                                                           .FindElement(ByIOS.Type("UIASecureTextField")));
            }
        }

        public SettingsView LogIn()
        {
            GetElement(ByIOS.Name("Login")).Click();

            bool isValid = true;

            try
            {
                Session.Driver.SwitchTo().Alert();
                isValid = false;
            } catch {}

            if(!isValid)
                throw new VerificationException("Invalid Login Credentials");

            this.WaitUntil(view => view.Tabs.SettingsTab.Tag.Displayed);

            return new SettingsView(Session);
        } 
    }
}
