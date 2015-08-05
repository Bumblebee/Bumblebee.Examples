using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nancy.Hosting.Self;

using NUnit.Framework;

namespace Bumblebee.Examples.Web.IntegrationTests.Shared
{
    [TestFixture]
    public abstract class HostTestFixture
    {
        private NancyHost _host;

        protected HostTestFixture()
            : this("http://localhost:1234")
        {
        }

        protected HostTestFixture(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        [TestFixtureSetUp]
        public void Init()
        {
            _host = new NancyHost(new Uri(BaseUrl));
            _host.Start();
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            _host.Dispose();
        }

        protected string GetUrl(string page)
        {
            return String.Format("{0}{1}{2}", BaseUrl, "/Content/", page);
        }

        protected string BaseUrl { get; private set; }
    }
}
