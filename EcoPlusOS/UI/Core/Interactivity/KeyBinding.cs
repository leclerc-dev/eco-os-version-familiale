using System;
using Cosmos.System;

namespace EcoPlusOS.UI.Core.Interactivity
{
    public class KeyBinding : InputBinding
    {
        public Modifier Modifier { get; set; }
        public ConsoleKeyEx MappedKey { get; set; }
        public KeyBinding(Action call, Modifier modifiers, ConsoleKeyEx mappedKey) : base(call)
        {
            Modifier = modifiers;
            MappedKey = mappedKey;
        }

        protected override bool ShouldTriggerImplementation()
        {
            if (KeyboardManager.TryReadKey(out var key) && key.Key == MappedKey)
            {
                // Long logic incoming :o
                if (Modifier == Modifier.None ||
                    (Modifier & Modifier.Alt) != Modifier.Alt || KeyboardManager.AltPressed && 
                    (Modifier & Modifier.Shift) != Modifier.Shift || KeyboardManager.ShiftPressed && 
                    (Modifier & Modifier.Ctrl) != Modifier.Ctrl || KeyboardManager.ControlPressed)
                {
                    return true;
                }
            }

            return false; // nope :c
        }
    }
    [Flags]
    public enum Modifier
    {
        None = 0,
        Ctrl = 1 << 0,
        Alt = 1 << 1,
        Shift = 1 << 2
    }
}