using System;
using Cosmos.System;

namespace EcoPlusOS.UI.Core.Interactivity
{
    public class MouseBinding : InputBinding
    {
        private readonly UIElement _element;
        public MouseState MouseStateTrigger { get; set; }
        public MouseBinding(Action call, UIElement element, MouseState state = MouseState.Left) : base(call)
        {
            _element = element;
            MouseStateTrigger = state;
        }

        protected override bool ShouldTriggerImplementation()
        {
            // collides, probably replace with UIElement (TODO you lazy)
            if (_element.LastRenderedBounds.Contains(MouseManagerEx.ToSystemPoint())) 
            {
                return (MouseManager.MouseState & MouseStateTrigger) == MouseStateTrigger;
            }

            return false;
        }
    }
}