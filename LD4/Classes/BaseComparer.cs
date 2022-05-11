using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD4
{
    public class BaseComparer<T> where T : IComparable<T>
    {
        public virtual int Compare(T l, T r)
        {
            return l.CompareTo(r);
        }
    }
}