using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //This is an interactive problem.
    //You are given an array of unique strings wordlist where wordlist[i] is 6 letters long, and one word in this list is chosen as secret.
    //You may call Master.guess(word) to guess a word.The guessed word should have type string and must be from the original list with 6 lowercase letters.
    //This function returns an integer type, representing the number of exact matches (value and position) of your guess to the secret word. Also, if your guess is not in the given wordlist, it will return -1 instead.
    //For each test case, you have exactly 10 guesses to guess the word. At the end of any number of calls, if you have made 10 or fewer calls to Master.guess and at least one of these guesses was secret, then you pass the test case.
    /// </summary>
    public class _00843_GuessTheWord_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Master master = new Master("acckzz", new string[] { "acckzz", "ccbazz", "eiowzz", "abcczz" });
            FindSecretWord(new string[] { "acckzz", "ccbazz", "eiowzz", "abcczz" }, master);
            Assert.AreEqual(true, master.WithinGuessLimit());

            master = new Master("hamada", new string[] { "hamada", "khaled" });
            FindSecretWord(new string[] { "hamada", "khaled" }, master);
            Assert.AreEqual(true, master.WithinGuessLimit());

            master = new Master("ccoyyo", new string[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" });
            FindSecretWord(new string[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" }, master);
            Assert.AreEqual(true, master.WithinGuessLimit());

            master = new Master("anqomr", new string[] { "pzrooh", "aaakrw", "vgvkxb", "ilaumf", "snzsrz", "qymapx", "hhjgwz", "mymxyu", "jglmrs", "yycsvl", "fuyzco", "ivfyfx", "hzlhqt", "ansstc", "ujkfnr", "jrekmp", "himbkv", "tjztqw", "jmcapu", "gwwwmd", "ffpond", "ytzssw", "afyjnp", "ttrfzi", "xkwmsz", "oavtsf", "krwjwb", "bkgjcs", "vsigmc", "qhpxxt", "apzrtt", "posjnv", "zlatkz", "zynlqc", "czajmi", "smmbhm", "rvlxav", "wkytta", "dzkfer", "urajfh", "lsroct", "gihvuu", "qtnlhu", "ucjgio", "xyycvd", "fsssoo", "kdtmux", "bxnppe", "usucra", "hvsmau", "gstvvg", "ypueay", "qdlvod", "djfbgs", "mcufib", "prohkc", "dsqgms", "eoasya", "kzplbv", "rcuevr", "iwapqf", "ucqdac", "anqomr", "msztnf", "tppefv", "mplbgz", "xnskvo", "euhxrh", "xrqxzw", "wraxvn", "zjhlou", "xwdvvl", "dkbiys", "zbtnuv", "gxrhjh", "ctrczk", "iwylwn", "wefuhr", "enlcrg", "eimtep", "xzvntq", "zvygyf", "tbzmzk", "xjptby", "uxyacb", "mbalze", "bjosah", "ckojzr", "ihboso", "ogxylw", "cfnatk", "zijwnl", "eczmmc", "uazfyo", "apywnl", "jiraqa", "yjksyd", "mrpczo", "qqmhnb", "xxvsbx" });
            FindSecretWord(new string[] { "pzrooh", "aaakrw", "vgvkxb", "ilaumf", "snzsrz", "qymapx", "hhjgwz", "mymxyu", "jglmrs", "yycsvl", "fuyzco", "ivfyfx", "hzlhqt", "ansstc", "ujkfnr", "jrekmp", "himbkv", "tjztqw", "jmcapu", "gwwwmd", "ffpond", "ytzssw", "afyjnp", "ttrfzi", "xkwmsz", "oavtsf", "krwjwb", "bkgjcs", "vsigmc", "qhpxxt", "apzrtt", "posjnv", "zlatkz", "zynlqc", "czajmi", "smmbhm", "rvlxav", "wkytta", "dzkfer", "urajfh", "lsroct", "gihvuu", "qtnlhu", "ucjgio", "xyycvd", "fsssoo", "kdtmux", "bxnppe", "usucra", "hvsmau", "gstvvg", "ypueay", "qdlvod", "djfbgs", "mcufib", "prohkc", "dsqgms", "eoasya", "kzplbv", "rcuevr", "iwapqf", "ucqdac", "anqomr", "msztnf", "tppefv", "mplbgz", "xnskvo", "euhxrh", "xrqxzw", "wraxvn", "zjhlou", "xwdvvl", "dkbiys", "zbtnuv", "gxrhjh", "ctrczk", "iwylwn", "wefuhr", "enlcrg", "eimtep", "xzvntq", "zvygyf", "tbzmzk", "xjptby", "uxyacb", "mbalze", "bjosah", "ckojzr", "ihboso", "ogxylw", "cfnatk", "zijwnl", "eczmmc", "uazfyo", "apywnl", "jiraqa", "yjksyd", "mrpczo", "qqmhnb", "xxvsbx" }, master);
            Assert.AreEqual(true, master.WithinGuessLimit());
        }

        //public void FindSecretWord(string[] wordlist, Master master)
        //{
        //    // Game Theory - Process of Elimination
        //    // Words still available to be guessed, that have not been ruled out
        //    // We use a linked list because we will be doing a lot of removing items from the middle of the list,
        //    // where LinkedList is fast at.
        //    LinkedList<string> activeWordList = new LinkedList<string>(wordlist);

        //    while (true)
        //    {
        //        if (!activeWordList.Any())
        //        {
        //            master.Guess("aaaaaa");
        //            break;
        //        }

        //        // Guess with the first active word
        //        var guess = activeWordList.First;
        //        int hits = master.Guess(guess.Value);

        //        // Found it?
        //        if (hits == 6)
        //            return;

        //        // Remove the guess from the active word list
        //        activeWordList.Remove(guess);

        //        // Remove any words that do not have this exact amount of hits
        //        // As none of those could be the answer
        //        for (var node = activeWordList.First; node != null; )
        //        {
        //            var next = node.Next;
        //            if (WordCompare(node.Value, guess.Value) != hits)
        //            {
        //                activeWordList.Remove(node);
        //            }
        //            node = next;
        //        }
        //    }
        //}

        // Online
        public void FindSecretWord(string[] wordlist, Master master)
        {
            // Game Theory - Process of Elimination
            // Words still available to be guessed, that have not been ruled out
            // We use a linked list because we will be doing a lot of removing items from the middle of the list,
            // where LinkedList is fast at.

            List<string> candidates = new List<string>(wordlist);

            Random rnd = new Random();

            for (int call = 0; call < 10; call++)
            {
                if (!candidates.Any())
                {
                    break;
                }

                // Guess with the first active word
                var guess = candidates[rnd.Next(candidates.Count())];
                int hits = master.Guess(guess);

                // Found it?
                if (hits == 6)
                    return;

                var newCandidates = new List<string>();
                // New candidates are any words that have this exact amount of hits
                // As only one of these could be the answer
                foreach (var word in candidates)
                {
                    if (WordCompare(word, guess) == hits)
                    {
                        newCandidates.Add(word);
                    }
                }
                candidates = newCandidates;
            }
        }

        /// <summary>
        /// Return the number of differences beteween two words
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int WordCompare(string word1, string word2)
        {
            int hits = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] == word2[i])
                {
                    hits++;
                }
            }
            return hits;
        }

        // This is the Master's API interface.
        // You should not implement it, or speculate about its implementation
        public class Master
        {
            private string _secret;
            private int _guessCount;
            private string[] _wordList;
            private bool _secretGuessed;
            private const int GUESSLIMIT = 10;
            public Master(string secret, string[] wordList)
            {
                _secret = secret;
                _guessCount = 0;
                _wordList = wordList;
                _secretGuessed = false;
            }
            public int Guess(string word)
            {
                if (!_wordList.Contains(word))
                {
                    return -1;
                }
                int hits = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == _secret[i])
                    {
                        hits++;
                    }
                }
                if (hits == 6 && _guessCount < GUESSLIMIT)
                {
                    _secretGuessed = true;
                }
                _guessCount++;
                return hits;
            }

            public bool WithinGuessLimit()
            {
                return _secretGuessed;
            }
        }
    }
}