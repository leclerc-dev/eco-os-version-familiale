using System;
using System.Collections.Generic;

namespace EcoPlusOS
{
    public class DelegateAggregator<T> : List<T> where T : Delegate
    {
        public delegate void Invoker(T d);
        public void Invoke(Invoker parameters)
        {
            foreach (var del in this)
            {
                parameters(del);
            }
        }
        public static DelegateAggregator<T> operator +(DelegateAggregator<T> aggr, T del)
        {
            aggr.Add(del);
            return aggr;
        }
        public static DelegateAggregator<T> operator -(DelegateAggregator<T> aggr, T del)
        {
            aggr.Remove(del);
            return aggr;
        }
    }
}