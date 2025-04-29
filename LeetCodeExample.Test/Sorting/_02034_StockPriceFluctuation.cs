using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given a stream of records about a particular stock.Each record contains a timestamp and the corresponding price of the stock at that timestamp.

    //   Unfortunately due to the volatile nature of the stock market, the records do not come in order.Even worse, some records may be incorrect.Another record with the same timestamp may appear later in the stream correcting the price of the previous wrong record.

    //  Design an algorithm that:

    //  Updates the price of the stock at a particular timestamp, correcting the price from any previous records at the timestamp.
    //Finds the latest price of the stock based on the current records. The latest price is the price at the latest timestamp recorded.
    //  Finds the maximum price the stock has been based on the current records.
    //  Finds the minimum price the stock has been based on the current records.
    //  Implement the StockPrice class:

    //  StockPrice() Initializes the object with no price records.
    //  void update(int timestamp, int price) Updates the price of the stock at the given timestamp.
    //  int current() Returns the latest price of the stock.
    //  int maximum() Returns the maximum price of the stock.
    //  int minimum() Returns the minimum price of the stock.
    /// </summary>
    public class _02034_StockPriceFluctuation
    {
        public class StockPrice
        {
            private readonly SortedSet<(int price, int timestamp)> _sortedSet;
            // key = timestamp
            private readonly Dictionary<int, (int price, int timestamp)> _dict;
            private int _current = 0;

            public StockPrice()
            {
                _sortedSet = new SortedSet<(int price, int timestamp)>();
                _dict = new Dictionary<int, (int price, int timestamp)>();
            }

            public void Update(int timestamp, int price)
            {
                _current = Math.Max(_current, timestamp);
                if (!_dict.ContainsKey(timestamp))
                {
                    var tuple = (price, timestamp);
                    _dict.Add(timestamp, tuple);
                    _sortedSet.Add(tuple);
                }
                else
                {
                    _sortedSet.Remove(_dict[timestamp]);
                    _dict.Remove(timestamp);
                    var tuple = (price, timestamp);
                    _dict.Add(timestamp, tuple);
                    _sortedSet.Add(tuple);
                }
            }

            public int Current()
            {
                return _dict[_current].price;
            }

            public int Maximum()
            {
                return _sortedSet.Max.price;
            }

            public int Minimum()
            {
                return _sortedSet.Min.price;
            }
        }


        //SortedSet<(int timestamp, int count)> sortedSet = new SortedSet<()>();

        // timestamp : price
        // Sorts in descending order
        //SortedDictionary<int, int> timestamps = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        //// price: count
        //SortedDictionary<int, int> ascendingPrices = new SortedDictionary<int, int>();
        //SortedDictionary<int, int> descendingPrices = new SortedDictionary<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        //public _02034_StockPriceFluctuation()
        //{

        //}

        //public void Update(int timestamp, int price)
        //{
        //    if (timestamps.ContainsKey(timestamp))
        //    {
        //        // Need to move from the old price to a new updated price
        //        int priceToRemove = timestamps[timestamp];
        //        ascendingPrices[priceToRemove]--;
        //        if (ascendingPrices[priceToRemove] <= 0)
        //            ascendingPrices.Remove(priceToRemove);
        //        descendingPrices[priceToRemove]--;
        //        if (descendingPrices[priceToRemove] <= 0)
        //            descendingPrices.Remove(priceToRemove);
        //    }
        //    timestamps[timestamp] = price;
        //    if (!ascendingPrices.ContainsKey(price))
        //        ascendingPrices.Add(price, 0);
        //    ascendingPrices[price]++;
        //    if (!descendingPrices.ContainsKey(price))
        //        descendingPrices.Add(price, 0);
        //    descendingPrices[price]++;
        //}

        //public int Current()
        //{
        //    return timestamps.First().Value;
        //}

        //public int Maximum()
        //{
        //    return descendingPrices.First().Key;
        //}

        //public int Minimum()
        //{
        //    return ascendingPrices.First().Key;
        //}
    }
}