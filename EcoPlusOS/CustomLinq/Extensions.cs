using System;
using System.Collections.Generic;

namespace EcoPlusOS.CustomLinq
{
    public static class Extensions
    {
        public delegate void AnyDelegate<in T>(T val, out bool result);

        public static bool Any<T>(this IEnumerable<T> enumerable, AnyDelegate<T> predicate)
        {
            Kernel.PrintDebug("Hi from any");
            var wrap = new ReferenceWrapper<bool>(false);
            Kernel.PrintDebug("ref yes");
            foreach (var thing in enumerable)
            {
                Kernel.PrintDebug("foreach ok");
                predicate(thing, out var result);
                Kernel.PrintDebug("predicate ok");
                if (result) return true;
            }
            return false;
        }

        public class ReferenceWrapper<T>
        {
            public T Value { get; set; }
            public ReferenceWrapper(T value)
            {
                Value = value;
            }

            public ReferenceWrapper() : this(default(T))
            {
                
            }
            public static implicit operator T(ReferenceWrapper<T> r) => r.Value;
            public static explicit operator ReferenceWrapper<T>(T val) => new ReferenceWrapper<T>(val);
        }
    }
}