using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bumblebee.Setup;
using BumblebeeIOS;
using BumblebeeIOS.Implementation;
using OpenQA.Selenium.Support.UI;

namespace BumblebeeExample.Tests.MobileTests
{
    public class MobileSession : Session
    {
        public MobileSession(IDriverEnvironment environment) : base(environment)
        {
            Monkey = new IOSMonkey();

            ((IOSMonkey)Monkey).SetProbability(0);
        }
    }
}
