
using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Anagrams
    {
        int GetMaximumSubset(string[] words)
        {
            List<Dictionary<Char, int>> counts = new List<Dictionary<Char, int>>();
            //Your code goes here
            foreach (string word in words)
            {
                counts.Add(makeDictionaryForWord(word));
            }
            bool nomore = false;
            int prevCount = 0;
            int currentCount = 1;
            while(prevCount!=counts.Count)
            {
                prevCount = counts.Count;
                for (int i = 0; i < counts.Count; i++)
                {
                    for (int j = i + 1; j < counts.Count; j++)
                    {
                        Dictionary<Char, int> word1 = counts[i];
                        Dictionary<Char, int> word2 = counts[j];
                        if (checkAnagram(word1, word2))
                        {
                            counts.Remove(word1);
                        }
                    }
                }
            }
            return counts.Count;
        }

        public static Dictionary<Char, int> makeDictionaryForWord(string word)
        {
            Dictionary<Char, int> dictionary = new Dictionary<Char, int>();
            foreach(Char letter in word)
            {
                if(dictionary.ContainsKey(letter))
                {
                    dictionary[letter] += 1;
                }
                else
                {
                    dictionary[letter] = 1;
                }
            }
            return dictionary;
        }

        public static bool checkAnagram(Dictionary<Char, int> dict, Dictionary<Char, int> dict2)
        {
            bool equal = false;
            if (dict.Count == dict2.Count) // Require equal count.
            {
                equal = true;
                foreach (var pair in dict)
                {
                    int value;
                    if (dict2.TryGetValue(pair.Key, out value))
                    {
                        // Require value be equal.
                        if (value != pair.Value)
                        {
                            equal = false;
                            break;
                        }
                    }
                    else
                    {
                        // Require key be present.
                        equal = false;
                        break;
                    }
                }
            }
            return equal;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            Anagrams anagramSolver = new Anagrams();
            do
            {
                string[] words = input.Split(',');
                Console.WriteLine(anagramSolver.GetMaximumSubset(words));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
