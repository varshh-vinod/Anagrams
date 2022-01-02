using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    class Anagrams
    {
        int GetMaximumSubset(string[] words)
        {
            List<String> wordss = new List<String>();
            foreach(string word in words)
            {
                Char[] letters = word.ToCharArray();
                Array.Sort(letters);
                String newWord =  new String(letters);
                if(!wordss.Contains(newWord))
                {
                    wordss.Add(newWord);
                }
            }
            return wordss.Count;
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
