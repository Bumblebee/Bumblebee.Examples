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
    public class SignInPage : WebBlock
    {
        public SignInPage(Session session) : base(session)
        {
        }

        public ITextField<SignInPage> UsernameField
        {
            get { return new TextField<SignInPage>(this, By.Id("Email"));}
        }

        public ITextField<SignInPage> PasswordField
        {
            get { return new TextField<SignInPage>(this, By.Id("Passwd"));}
        }

        public IClickable<GmailPage> SignInButton
        {
            get { return new Clickable<GmailPage>(this, By.Id("signIn")); }
        }

        public ICheckbox<SignInPage> StaySignedInCheckbox
        {
            get { return new Checkbox<SignInPage>(this, By.Id("PersistentCookie"));}
        }
    }
}
