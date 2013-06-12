using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Bumblebee.Extensions;
using Bumblebee.Setup;
using BumblebeeExample.Tests.MobileTests.Attributes;
using BumblebeeIOS;
using BumblebeeIOS.Implementation;
using MbUnit.Framework;
using OpenQA.Selenium.Remote;

namespace BumblebeeExample.Tests.MobileTests
{
    public abstract class MobileTestSuite
    {
        private readonly ThreadLocal<Session> _threadLocalSession = new ThreadLocal<Session>();

        protected  Session Session
        {
            get { return _threadLocalSession.Value; }
            private set { _threadLocalSession.Value = value; }
        }

        private Dictionary<string, object> GetJsonMap()
        {
            var jsonMap = new Dictionary<string, object>();

            jsonMap["simulator"] = true;
            jsonMap["CFBundleName"] = "AlienBlue";
            jsonMap["locale"] = "en_GB";
            jsonMap["variation"] = "Regular";
            jsonMap["timeHack"] = false;
            jsonMap["device"] = "iphone";
            jsonMap["CFBundleVerson"] = "202949";
            jsonMap["language"] = "en";
            jsonMap["javascriptEnabled"] = true;

            return jsonMap;
        }

        [SetUp]
        public virtual void SetUp()
        {
            Session = new MobileSession(
                                        new RemoteIOSEnvironment("http://10.211.55.2:5555/wd/hub",
                                        new DesiredCapabilities(GetJsonMap()), 
                                        TimeSpan.FromSeconds(60)));

            try
            {
                string dangerLevel = Metadata.Get("MonkeyTest").First();
                
                ((IOSMonkey)Session.Monkey).SetProbability(Double.Parse(dangerLevel));
            }
            catch (InvalidOperationException)
            {
            }

            Initialize();
        }

        public virtual void Initialize()
        {
        }

        [TearDown]
        public virtual void TearDown()
        {
            try
            {
                Metadata.Get("MonkeyTest").First();
                Session.Monkey.Logs.Each(Console.WriteLine);
            } catch (InvalidOperationException){}

            Session.End();
        }
    }
}
