using Bumblebee.Implementation;
using Bumblebee.Interfaces;
using OpenQA.Selenium;

namespace BumblebeeExample
{
    public class AriaCheckbox<TResult> : Checkbox<TResult> where TResult : IBlock
    {
        public AriaCheckbox(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public AriaCheckbox(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public override bool Selected
        {
            get { return Tag.GetAttribute("aria-checked") == "true"; }
        }
    }
}
