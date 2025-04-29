using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Common
{
    // Key Value Pair where you can modify the value;
    public class KeyVal<TKey, Val> : IComparable<KeyVal<TKey, Val>>
        where Val : IComparable<Val>
    {
        public TKey Key { get; set; }
        public Val Value { get; set; }

        public KeyVal() { }

        public KeyVal(TKey key, Val val)
        {
            this.Key = key;
            this.Value = val;
        }

        public int CompareTo(KeyVal<TKey, Val> other)
        {
            return Value.CompareTo(other.Value);
            //if (this.Value > other.Value)
            //    return 1;
            //else if (this.Value < other.Value)
            //    return -1;
            //return 0;
        }
    }
}
