using System.Threading;
using Bumblebee.Setup;
using MbUnit.Framework;

namespace BumblebeeExample.Tests.Infrastructure
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
        }

        [TearDown]
        public virtual void TearDown()
        {
            Session.End();
        }
    }
}
