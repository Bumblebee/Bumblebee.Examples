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
            Session = new MobileSession(new RemoteIOSEnvironment("http://10.211.55.2:5555/wd/hub", GetJsonMap()));

            try
            {
                string dangerLevel = Metadata.Get("MonkeyTest").First();
                switch (dangerLevel)
                {
                    case "LOW":
                        Session.Monkey.Probability = 0.2;
                        break;
                    case "MEDIUM":
                        Session.Monkey.Probability = 0.5;
                        break;
                    case "HIGH":
                        Session.Monkey.Probability = 0.8;
                        break;
                    case "MONKEY_BUSINESS":
                        Session.Monkey.Probability = 1.0;
                        break;
                    default:
                        Session.Monkey.Probability = 0.5;
                        break;
                }
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
            Console.WriteLine(Session.Monkey.Probability);

            //if(Session.Monkey.Probability > 0.1)
              //  Session.Monkey.Logs.Each(Console.WriteLine);

            Session.End();
        }
    }
}
