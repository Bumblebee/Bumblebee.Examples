using System.Linq;
using Bumblebee.Extensions;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public class FacebookTests : TestSuite
    {
        [Test]
        public void LogIn()
        {
            Session.CurrentBlock<SignInPage>()
                   .EmailField.EnterText("bumblebee.example@gmail.com")
                   .PasswordField.EnterText("123abc!!")
                   .LogInButton.Click<WebBlock>();
        }
    }
}
