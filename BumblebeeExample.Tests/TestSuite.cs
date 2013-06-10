using System;
using System.Threading;
using Bumblebee.Setup;
using MbUnit.Framework;

namespace BumblebeeExample.Tests
{
    public abstract class TestSuite
    {
        private readonly ThreadLocal<Session> _threadLocalSession = new ThreadLocal<Session>();

        protected  Session Session
        {
            get { return _threadLocalSession.Value; }
            private set { _threadLocalSession.Value = value; }
        }

        [SetUp]
        public virtual void SetUp()
        {
            Session = new Session(new LocalChromeEnvironment());
            Session.NavigateTo<SignInPage>("http://www.facebook.com");
        }

        [TearDown]
        public virtual void TearDown()
        {
            Session.End();
        }
    }
}
