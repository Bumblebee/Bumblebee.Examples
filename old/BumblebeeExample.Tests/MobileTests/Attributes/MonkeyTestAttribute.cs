using System;
using System.Collections.Generic;
using Gallio.Framework.Pattern;

namespace BumblebeeExample.Tests.MobileTests.Attributes
{
    [AttributeUsage(PatternAttributeTargets.TestComponent, AllowMultiple = false, Inherited = true)]
    public class MonkeyTestAttribute : MetadataPatternAttribute
    {
        public DangerLevel DangerLevel { get; set; }

        private double _danger;

        public MonkeyTestAttribute()
        {
            switch (DangerLevel)
            {
                case DangerLevel.LOW:
                    _danger = 0.2;
                    break;
                case DangerLevel.MEDIUM:
                    _danger = 0.5;
                    break;
                case DangerLevel.HIGH:
                    _danger = 0.8;
                    break;
                case DangerLevel.MONKEY_BUSINESS:
                    _danger = 1.0;
                    break;
                default:
                    _danger = 0.5;
                    break;
            }
        }

        protected override IEnumerable<KeyValuePair<string, string>> GetMetadata()
        {
            yield return new KeyValuePair<string, string>("MonkeyTest", _danger.ToString());
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
