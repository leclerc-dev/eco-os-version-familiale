using System;

namespace EcoPlusOS.UI.Core.Interactivity
{
    public abstract class InputBinding
    {
        public Action Callback { get; set; }
        // i spent 5 minutes debugging and found it was just because there weren't any true by default lmao
        public bool Enabled { get; set; } = true; 
        protected abstract bool ShouldTriggerImplementation();

        public virtual void DisableHooks()
        {
            Enabled = false;
        }
        public bool ShouldTrigger()
        {
            if (!Enabled) return false;
            return ShouldTriggerImplementation();
        }

        public virtual void Process()
        {
            if (Callback != null && ShouldTrigger())
            {
                Callback();
            }
        }
        public InputBinding(Action call)
        {
            Callback = call;
        }
    }
}