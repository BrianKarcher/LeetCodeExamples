using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given two string arrays username and website and an integer array timestamp.All the given arrays are of the same length and the tuple[username[i], website[i], timestamp[i]] indicates that the user username[i] visited the website website[i] at time timestamp[i].

//A pattern is a list of three websites (not necessarily distinct).

//For example, ["home", "away", "love"], ["leetcode", "love", "leetcode"], and["luffy", "luffy", "luffy"] are all patterns.
//The score of a pattern is the number of users that visited all the websites in the pattern in the same order they appeared in the pattern.

//For example, if the pattern is ["home", "away", "love"], the score is the number of users x such that x visited "home" then visited "away" and visited "love" after that.
//Similarly, if the pattern is ["leetcode", "love", "leetcode"], the score is the number of users x such that x visited "leetcode" then visited "love" and visited "leetcode" one more time after that.
//Also, if the pattern is ["luffy", "luffy", "luffy"], the score is the number of users x such that x visited "luffy" three different times at different timestamps.
//Return the pattern with the largest score.If there is more than one pattern with the same largest score, return the lexicographically smallest such pattern.
/// </summary>
public class _01152_AnalyzeUserWebsiteVisitPattern
{
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {
        Dictionary<string, List<(string Username, int Timestamp, string Website)>> userPageVisitMap = new();
        for (int i = 0; i < username.Length; i++)
        {
            userPageVisitMap.TryAdd(username[i], new List<(string Username, int Timestamp, string Website)>());
            userPageVisitMap[username[i]].Add((username[i], timestamp[i], website[i]));
        }
        Dictionary<(string w1, string w2, string w3), HashSet<string>> counts = new();
        foreach (var userPageVisit in userPageVisitMap)
        {
            IList<(string Username, int Timestamp, string Website)> orderedList = userPageVisit.Value.OrderBy(i => i.Timestamp).ToList();
            /*foreach (var ord in orderedList) {
                Console.WriteLine($"{ord.Username} {ord.Website}");
            }*/
            for (int i = 0; i < orderedList.Count - 2; i++)
            {
                for (int j = i + 1; j < orderedList.Count - 1; j++)
                {
                    for (int k = j + 1; k < orderedList.Count; k++)
                    {
                        counts.TryAdd((orderedList[i].Website, orderedList[j].Website, orderedList[k].Website), new HashSet<string>());
                        //Console.WriteLine($"{orderedList[i].Username}, {orderedList[i].Website}, {orderedList[j].Website}, {orderedList[k].Website}");
                        counts[(orderedList[i].Website, orderedList[j].Website, orderedList[k].Website)].Add(userPageVisit.Key);
                    }
                }
            }
        }

        List<string> rtn = new();
        int maxCount = Int32.MinValue;
        //counts.OrderByDescending(i => i, (a, b) => { a. });
        foreach (var count in counts)
        {
            //Console.WriteLine($"{count.Key.w1} {count.Key.w2} {count.Key.w3} = {count.Value}");
            if (count.Value.Count > maxCount)
            {
                rtn = WordsToList(count.Key);
                maxCount = count.Value.Count;
            }
            else if (count.Value.Count == maxCount)
            {
                if (count.Key.w1.CompareTo(rtn[0]) < 0)
                {
                    rtn = WordsToList(count.Key);
                    continue;
                }
                if (count.Key.w1.CompareTo(rtn[0]) > 0)
                {
                    continue;
                }
                if (count.Key.w2.CompareTo(rtn[1]) < 0)
                {
                    rtn = WordsToList(count.Key);
                    continue;
                }
                if (count.Key.w2.CompareTo(rtn[1]) > 0)
                {
                    continue;
                }
                if (count.Key.w3.CompareTo(rtn[2]) < 0)
                {
                    rtn = WordsToList(count.Key);
                    continue;
                }
                if (count.Key.w3.CompareTo(rtn[2]) > 0)
                {
                    continue;
                }
            }
        }
        return rtn;
    }

    List<string> WordsToList((string w1, string w2, string w3) words)
    {
        return new List<string>() { words.w1, words.w2, words.w3 };
    }
}