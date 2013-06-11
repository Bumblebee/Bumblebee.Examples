using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallio.Framework.Pattern;

namespace BumblebeeExample.Tests.MobileTests.Attributes
{
    [AttributeUsage(PatternAttributeTargets.TestComponent, AllowMultiple = false, Inherited = true)]
    public class MonkeyTestAttribute : MetadataPatternAttribute
    {
        public DangerLevel DangerLevel { get; set; }

        public MonkeyTestAttribute()
        {
            DangerLevel = DangerLevel.HIGH;
        }

        protected override IEnumerable<KeyValuePair<string, string>> GetMetadata()
        {
            yield return new KeyValuePair<string, string>("MonkeyTest", DangerLevel.ToString());
        }
    }

    public enum DangerLevel
    {
        LOW,
        MEDIUM,
        HIGH,
        MONKEY_BUSINESS
    }
}
