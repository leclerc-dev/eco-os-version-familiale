using System;
using Cosmos.System;
using static Cosmos.System.KeyboardManager;
namespace EcoPlusOS.UI.Core.Interactivity
{
    public class KeyBinding : InputBinding
    {
        public Modifier Modifier { get; set; }
        public ConsoleKeyEx MappedKey { get; set; }
        public static KeyEvent LastEvent;
        public KeyBinding(Action call, ConsoleKeyEx mappedKey, Modifier modifiers = Modifier.None) : base(call)
        {
            Modifier = modifiers;
            MappedKey = mappedKey;
        }

        public static void UpdateKey()
        {
            TryReadKey(out LastEvent);
        }
        protected override bool ShouldTriggerImplementation()
        {
            return LastEvent?.Key == MappedKey &&
                   (Modifier == Modifier.None  ||
                   (Modifier &  Modifier.Alt)   != Modifier.Alt   || AltPressed   &&
                   (Modifier &  Modifier.Shift) != Modifier.Shift || ShiftPressed &&
                   (Modifier &  Modifier.Ctrl)  != Modifier.Ctrl  || ControlPressed); // looks clean :)
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