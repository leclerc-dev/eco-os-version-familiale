using System;
using System.Collections.Generic;

namespace EcoPlusOS
{
    public class DelegateAggregator<T> : List<T> where T : Delegate
    {
        public void Invoke(Action<T> parameters)
        {
            foreach (var del in this)
            {
                if (del == null) continue;
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