using System;
using System.Collections.Generic;
using System.Threading;
using Bumblebee.Setup;
using BumblebeeIOS;
using BumblebeeIOS.Implementation;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
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
            Session = new Session(new RemoteIOSEnvironment("http://10.211.55.2:5555/wd/hub", GetJsonMap()));
        }

        [TearDown]
        public virtual void TearDown()
        {
            Session.End();
        }
    }
}
