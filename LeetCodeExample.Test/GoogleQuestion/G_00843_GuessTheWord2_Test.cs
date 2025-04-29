using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // This is an interactive problem.
    // You are given an array of unique strings wordlist where wordlist[i] is 6 letters long, and one word in this list is chosen as secret.
    // You may call Master.guess(word) to guess a word.The guessed word should have type string and must be from the original list with 6 lowercase letters.
    // This function returns an integer type, representing the number of exact matches (value and position) of your guess to the secret word. Also, if your guess is not in the given wordlist, it will return -1 instead.
    // For each test case, you have exactly 10 guesses to guess the word. At the end of any number of calls, if you have made 10 or fewer calls to Master.guess and at least one of these guesses was secret, then you pass the test case.
    /// </summary>
    public class _00843_GuessTheWord2_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Master master = new Master("acckzz", new string[] { "acckzz", "ccbazz", "eiowzz", "abcczz" });
            FindSecretWord(master._wordList, master);
            Assert.AreEqual(true, master.Found);

            master = new Master("hamada", new string[] { "hamada", "khaled" });
            FindSecretWord(master._wordList, master);
            Assert.AreEqual(true, master.Found);

            master = new Master("ccoyyo", new string[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" });
            FindSecretWord(master._wordList, master);
            Assert.AreEqual(true, master.Found);

            master = new Master("anqomr", new string[] { "pzrooh", "aaakrw", "vgvkxb", "ilaumf", "snzsrz", "qymapx", "hhjgwz", "mymxyu", "jglmrs", "yycsvl", "fuyzco", "ivfyfx", "hzlhqt", "ansstc", "ujkfnr", "jrekmp", "himbkv", "tjztqw", "jmcapu", "gwwwmd", "ffpond", "ytzssw", "afyjnp", "ttrfzi", "xkwmsz", "oavtsf", "krwjwb", "bkgjcs", "vsigmc", "qhpxxt", "apzrtt", "posjnv", "zlatkz", "zynlqc", "czajmi", "smmbhm", "rvlxav", "wkytta", "dzkfer", "urajfh", "lsroct", "gihvuu", "qtnlhu", "ucjgio", "xyycvd", "fsssoo", "kdtmux", "bxnppe", "usucra", "hvsmau", "gstvvg", "ypueay", "qdlvod", "djfbgs", "mcufib", "prohkc", "dsqgms", "eoasya", "kzplbv", "rcuevr", "iwapqf", "ucqdac", "anqomr", "msztnf", "tppefv", "mplbgz", "xnskvo", "euhxrh", "xrqxzw", "wraxvn", "zjhlou", "xwdvvl", "dkbiys", "zbtnuv", "gxrhjh", "ctrczk", "iwylwn", "wefuhr", "enlcrg", "eimtep", "xzvntq", "zvygyf", "tbzmzk", "xjptby", "uxyacb", "mbalze", "bjosah", "ckojzr", "ihboso", "ogxylw", "cfnatk", "zijwnl", "eczmmc", "uazfyo", "apywnl", "jiraqa", "yjksyd", "mrpczo", "qqmhnb", "xxvsbx" });
            FindSecretWord(master._wordList, master); 
            Assert.AreEqual(true, master.Found);
        }

        public void FindSecretWord(string[] wordlist, Master master)
        {
            Random rnd = new Random();
            // We can remove from lists
            List<string> lstWords = new List<string>(wordlist);
            for (int i = 0; i < 10; i++)
            {
                // Pick a word
                int pick = rnd.Next(lstWords.Count);
                string strPick = lstWords[pick];
                int correctCount = master.Guess(strPick);
                if (correctCount == 6)
                    return;
                lstWords.Remove(strPick);
                // Loop through the words, and only keep the ones with the same amount of correct letters as the secret
                for (int j = lstWords.Count - 1; j >= 0; j--)
                {
                    int cmp = WordCompare(strPick, lstWords[j]);
                    if (cmp != correctCount)
                        lstWords.RemoveAt(j);
                }
            }
        }

        public int WordCompare(string w1, string w2)
        {
            int c = 0;
            for (int i = 0; i < w1.Length; i++)
            {
                if (w1[i] == w2[i])
                    c++;
            }
            return c;
        }

        public class Master
        {
            public bool Found = false;
            string _secret;
            public string[] _wordList;

            public Master(string secret, string[] wordList)
            {
                _secret = secret;
                _wordList = wordList;
            }

            public int Guess(string word)
            {
                if (!_wordList.Contains(word))
                    return -1;

                int c = 0;
                if (_secret == word)
                    Found = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == _secret[i])
                        c++;
                }
                return c;
            }
        }
    }
}