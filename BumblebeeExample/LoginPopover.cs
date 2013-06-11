using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class LoginOrRegisterPopover : WebBlock
    {
        public LoginOrRegisterPopover(Session session) : base(session)
        {
            Tag = GetElement(By.ClassName("login-popup"));
        }

        public LoginPopover LoginForm
        {
            get { return new LoginPopover(Session); }
        }
    }

    public class LoginPopover : WebBlock
    {
        public LoginPopover(Session session) : base(session)
        {
            Tag = GetElement(By.ClassName("login-form-section"));
        }

        public ITextField<LoginPopover> Email
        {
            get { return new TextField<LoginPopover>(this, By.Id("user_login")); }
        }

        public ITextField<LoginPopover> Password
        {
            get { return new TextField<LoginPopover>(this, By.Id("passwd_login")); }
        }

        public IClickable LoginButton
        {
            get { return new Clickable(this, By.CssSelector(".submit button")); }
        }
    }
}
