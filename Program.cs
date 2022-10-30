using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Humara
{
    class Program
    {
        private static readonly char[] WORD_DELIMETERS = new char[] {' ','.',',','?','!',';'};
        private static readonly char[] SENTENCE_DELIMETERS = new char[] {'.','!','?'};

        // With M being the number of words in the paragraph
        // With N being the number of characters in the current word
        // With P being the number of characters in the paragraph string (from string.Split())

        private static int CalculateNumberOfPalindromeWords(string paragraph)
        {
            // Time Complexity: O(M*(N/2)) && Space Complexity: O(P)
            int numberOfPalindromeWords = 0;
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                if (CheckIfWordIsPalindrome(word))
                {
                    numberOfPalindromeWords++;
                }
            }
            return numberOfPalindromeWords;
        }

        private static bool CheckIfWordIsPalindrome(string word)
        {
            for(int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length-i-1])
                {
                    return false;
                }
            }
            return true;
        }

        private static int CalculateNumberOfPalindromeSentences(string paragraph)
        {
            // Time Complexity: O(M*(N/2)) && Space Complexity: O(N*P)
            int numberOfPalindromeSentences = 0;
            foreach(string sentence in GetListOfSentencesFromString(paragraph))
            {
                var listOfWords = GetListOfWordsFromString(sentence);
                bool isPalindrome = true;
                for (int i = 0; i < listOfWords.Count/2; i++)
                {
                    if (listOfWords[i] != listOfWords[listOfWords.Count-i-1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if (isPalindrome)
                {
                    numberOfPalindromeSentences++;
                }
            }

            return numberOfPalindromeSentences;
        }

        private static Dictionary<string, int> GetListAndCountOfUniqueWords(string paragraph)
        {
            // Time Complexity: O(M) && Space Complexity: O(P)
            Dictionary<string, int> uniqueWordsAndCounts = new Dictionary<string, int>();
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                if (uniqueWordsAndCounts.ContainsKey(word))
                {
                    uniqueWordsAndCounts[word]++;
                }
                else
                {
                    uniqueWordsAndCounts.Add(word, 1);
                }
            }
            return uniqueWordsAndCounts;
        }

        public static List<string> GetAllWordsFromParagraphContainingInputLetter(string paragraph, char letter)
        {
            // Time Complexity: O(M) && Space Complexity: O(P)
            List<string> wordsContainingLetter = new List<string>();
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                if (word.Contains(letter) && !wordsContainingLetter.Contains(word))
                {
                    wordsContainingLetter.Add(word);
                }
            }
            return wordsContainingLetter;
        }

        private static char GetInputCharacter()
        {
            Console.WriteLine($"Please input character for {nameof(GetInputCharacter)} function:");
            char returnChar = Char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");
            return returnChar;
        }

        private static string GetInputParagraph(){
            Console.WriteLine($"Please input paragraph for {nameof(GetInputParagraph)} function:");
            return Console.ReadLine();
        }

        private static List<string> GetListOfWordsFromString(string paragraph)
        {
            return new List<string>(paragraph.ToLower().Split(WORD_DELIMETERS, StringSplitOptions.RemoveEmptyEntries));
        }
        
        private static List<string> GetListOfSentencesFromString(string paragraph)
        {
            return new List<string>(paragraph.ToLower().Split(SENTENCE_DELIMETERS, StringSplitOptions.RemoveEmptyEntries));
        }

        static void Main(string[] args)
        {
            string paragraph = GetInputParagraph();
            BenchmarkFunction(() => Console.WriteLine(CalculateNumberOfPalindromeWords(paragraph)), nameof(CalculateNumberOfPalindromeWords));
            BenchmarkFunction(() => Console.WriteLine(CalculateNumberOfPalindromeSentences(paragraph)), nameof(CalculateNumberOfPalindromeSentences));
            BenchmarkFunction(() => 
                { 
                    foreach(var pair in GetListAndCountOfUniqueWords(paragraph)) 
                    { 
                        Console.WriteLine($"{pair.Key} : {pair.Value}"); 
                    } 
                }, nameof(GetListAndCountOfUniqueWords));

            char inputLetter = GetInputCharacter();
            BenchmarkFunction(() => 
                { 
                    foreach(string word in GetAllWordsFromParagraphContainingInputLetter(paragraph, inputLetter))
                    { 
                        Console.WriteLine(word); 
                    } 
                }, nameof(GetAllWordsFromParagraphContainingInputLetter));
        }

        private static void BenchmarkFunction(Action function, string nameOfFunction)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            function.Invoke();
            sw.Stop();
            Console.WriteLine($"{nameOfFunction}: {sw.Elapsed}\n");
        }
    }
}