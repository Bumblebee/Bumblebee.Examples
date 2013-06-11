using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Framework;

namespace BumblebeeExample.Tests.MobileTests.Attributes
{
    public static class Metadata
    {
        public static IEnumerable<string> Get(string key)
        {
            var test = TestContext.CurrentContext.Test;
            IEnumerable<string> ids = new string[] { };

            while (test != null)
            {
                ids = ids.Concat(test.Metadata[key]);
                test = test.Parent;
            }

            return ids;
        }
    }
}
