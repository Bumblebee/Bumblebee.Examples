using System.Linq;
using Bumblebee.Extensions;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public class GmailTests : TestSuite
    {
        [Test]
        public void LogIn()
        {
            Session.CurrentBlock<SignInPage>()
                   .UsernameField.EnterText("bumblebee.example")
                   .PasswordField.EnterText("123abc!!")
                   .SignInButton.Click()
                   .Verify("there are two read links", page => page.InboxRows.Count(row => !row.Unread) == 2)
                   .InboxRows.Last().Checkbox.Check()
                   .ScopeTo<GmailPage>()
                   .InboxRows.ElementAt(1).Link.Click<WebBlock>();
        }
    }
}
