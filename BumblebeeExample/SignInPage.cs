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

        public ITextField<SignInPage> EmailField
        {
            get { return new TextField<SignInPage>(this, By.Id("email"));}
        }

        public ITextField<SignInPage> PasswordField
        {
            get { return new TextField<SignInPage>(this, By.Id("pass"));}
        }

        public IClickable LogInButton
        {
            get { return new Clickable(this, By.Id("loginbutton")); }
        }

        public ICheckbox KeepMeLoggedInCheckbox
        {
            get { return new Checkbox(this, By.Id("persist_box")); }
        }
    }
}
