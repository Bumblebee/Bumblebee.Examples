using Bumblebee.Extensions;
using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class WebBlock : Block
    {
        public WebBlock(Session session) : base(session)
        {
            Tag = Session.Driver.GetElement(By.TagName("body"));
        }
    }
}
