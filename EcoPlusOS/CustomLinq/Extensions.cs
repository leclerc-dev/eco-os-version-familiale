using System;
using System.Collections.Generic;
using System.Net;

namespace EcoPlusOS.CustomLinq
{
    public static class Extensions
    {
        public delegate void PredicateDelegate<in T>(T val, ReferenceWrapper<bool> result);
        public delegate void SelectDelegate<in TIn, TOut>(TIn input, out TOut result);

        private static void TruePredicate<T>(T val, out bool result) => result = true;
        public static bool Any<T>(this List<T> enumerable, PredicateDelegate<T> predicate = null)
        {
            if (predicate == null)
            {
                return enumerable.Count > 0;
            }
            Kernel.PrintDebug("Hi from any");
            var wrap = new ReferenceWrapper<bool>(false);
            Kernel.PrintDebug("ref yes");
            foreach (var thing in enumerable)
            {
                Kernel.PrintDebug("foreach ok");
                predicate(thing, wrap);
                Kernel.PrintDebug("predicate ok");
                if (wrap) return true;
            }
            return false;
        }
        //public static bool Any<T>(this T[] array, PredicateDelegate<T> predicate) => array.ToList().Any(predicate);

        public static List<TOut> Select<TIn, TOut>(this IEnumerable<TIn> input, SelectDelegate<TIn, TOut> select)
        {
            var list = new List<TOut>();
            foreach (var thing in input)
            {
                select(thing, out var result);
                list.Add(result);
            }

            return list;
        }

        //public static List<TOut> Select<TIn, TOut>(this TIn[] input, SelectDelegate<TIn, TOut> select) =>
        //    input.ToList().Select(select);

        public static List<T> Where<T>(this IEnumerable<T> enumerable, PredicateDelegate<T> predicate)
        {
            var list = new List<T>();
            foreach (var thing in enumerable)
            {
                var wrap = new ReferenceWrapper<bool>(false);
                predicate(thing, wrap);
                if (wrap)
                {
                    list.Add(thing);
                }
            }

            return list;
        }
        //public static List<T> Where<T>(this T[] enumerable, PredicateDelegate<T> predicate) =>
        //    enumerable.ToList().Where(predicate);
        public static int CustomIndexOf<T>(this IList<T> list, ref T element) where T : class
        {
            for (int i = 0; i < list.Count; i++)
            {
                Kernel.PrintDebug("Custom index owo what's the " + i + "?");
                if (list[i] == element) return i;
            }

            return -1;
        }

        public static List<T> Skip<T>(this List<T> list, int count)
        {
            var copy = new List<T>();
            Kernel.PrintDebug("Let's skip");
            if (count <= 0) count = 1;
            for (int i = count - 1; i < list.Count; i++)
            {
                Kernel.PrintDebug("Skipping: " + i);
                copy.Add(list[i]);
            }
            return copy;
        }

        public static List<T> CustomReverse<T>(this List<T> list)
        {
            var copy = new List<T>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Kernel.PrintDebug("adding reverse: " + i);
                copy.Add(list[i]);
            }
            return copy;
        }
        public static List<T> ToList<T>(this T[] array)
        {
            var l = new List<T>();
            foreach (var thing in array)
            {
                l.Add(thing);
            }

            return l;
        }
        public class ReferenceWrapper<T>
        {
            public T Value { get; set; }
            public ReferenceWrapper(T value)
            {
                Value = value;
            }

            public ReferenceWrapper() : this(default)
            {
                
            }
            public static implicit operator T(ReferenceWrapper<T> r) => r.Value;
            public static explicit operator ReferenceWrapper<T>(T val) => new ReferenceWrapper<T>(val);
        }
    }
}