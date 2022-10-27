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

        private static int CalculateNumberOfPalindromeWords(string paragraph)
        {
            // O(N) && O(N) TIME / SPACE 
            int numberOfPalindromeWords = 0;
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                if (CheckIfWordIsPalindrome(word.ToLower()))
                {
                    numberOfPalindromeWords++;
                }
            }
            return numberOfPalindromeWords;
        }

        private static bool CheckIfWordIsPalindrome(string word){
            for(int i = 0; i < word.Length; i++)
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
            int numberOfPalindromeSentences = 0;
            foreach(string sentence in GetListOfSentencesFromString(paragraph))
            {
                var listOfWords = GetListOfWordsFromString(sentence);
                bool isPalindrome = true;
                for (int i = 0; i < listOfWords.Count; i++)
                {
                    if (listOfWords[i].ToLower() != listOfWords[listOfWords.Count-i-1].ToLower())
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

        private static Dictionary<string, int> GetListAndCountOfUniqueWords(string paragraph, bool ignoreCase = false)
        {
            Dictionary<string, int> uniqueWordsAndCounts = new Dictionary<string, int>();
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                string newWord = word;
                if (ignoreCase)
                {
                    newWord = word.ToLower();
                }
                if (uniqueWordsAndCounts.ContainsKey(newWord))
                {
                    uniqueWordsAndCounts[newWord]++;
                }
                else
                {
                    uniqueWordsAndCounts.Add(newWord, 1);
                }
            }

            return uniqueWordsAndCounts;
        }

        public static List<string> GetAllWordsFromParagraphContainingInputLetter(string paragraph, char letter){
            List<string> wordsContainingLetter = new List<string>();
            foreach(string word in GetListOfWordsFromString(paragraph))
            {
                if (word.ToLower().Contains(letter) && !wordsContainingLetter.Contains(word))
                {
                    wordsContainingLetter.Add(word);
                }
            }
            return wordsContainingLetter;
        }

        private static char GetInputLetter()
        {
            return Console.ReadKey().KeyChar;
        }

        private static string GetInputParagraph(){
            return Console.ReadLine();
        }

        private static List<string> GetListOfWordsFromString(string paragraph)
        {
            return new List<string>(paragraph.Split(WORD_DELIMETERS, StringSplitOptions.RemoveEmptyEntries));
        }
        
        private static List<string> GetListOfSentencesFromString(string paragraph)
        {
            return new List<string>(paragraph.Split(SENTENCE_DELIMETERS, StringSplitOptions.RemoveEmptyEntries));
        }

        static void Main(string[] args)
        {
            string paragraph = GetInputParagraph();

            BenchmarkFunction(() => Console.WriteLine(CalculateNumberOfPalindromeWords(paragraph)), nameof(CalculateNumberOfPalindromeWords));
            BenchmarkFunction(() => Console.WriteLine(CalculateNumberOfPalindromeSentences(paragraph)), nameof(CalculateNumberOfPalindromeSentences));
            BenchmarkFunction(() => 
                { 
                    foreach(var pair in GetListAndCountOfUniqueWords(paragraph, true)) 
                    { 
                        Console.WriteLine($"{pair.Key} : {pair.Value}"); 
                    } 
                }, nameof(GetListAndCountOfUniqueWords));
            BenchmarkFunction(() => 
                { 
                    char inputLetter = GetInputLetter();
                    foreach(string word in GetAllWordsFromParagraphContainingInputLetter(paragraph, (char)inputLetter))
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
            Console.WriteLine($"{nameOfFunction}: {sw.Elapsed}");
        }
    }
}

/*
Coding Assessment
Using VS Code, write a C# solution to take in an input of a paragraph and:
1) Give the number of palindrome words
2) Give the number of palindrome sentences
3) List the unique words of a paragraph with the count of the word instance
4) Let the user also input a letter at some point and list all words containing that letter 

Write up a short documentation explaining what your program does.

Upload the program to GitHub or alternative Git repository hosting service. Once you have done so, send that link to me to forward to the managers for review. 
*/