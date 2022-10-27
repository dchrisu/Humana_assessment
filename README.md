Hello all those viewing. This is my solution to the Coding Assessment provided.

Coding Assessment
Using VS Code, write a C# solution to take in an input of a paragraph and:
1) Give the number of palindrome words
    - CalculateNumberOfPalindromeWords()
2) Give the number of palindrome sentences
    - CalculateNumberOfPalindromeSentences()
3) List the unique words of a paragraph with the count of the word instance
    - GetListAndCountOfUniqueWords()
4) Let the user also input a letter at some point and list all words containing that letter
    - GetAllWordsFromParagraphContainingInputLetter()

Write up a short documentation explaining what your program does:

1) CalculateNumberOfPalindromeWords iterates through a readable list of words from the given sample paragraph, stepping through each word, we CheckIfWordIsPalindrome(). The CheckIfWordIsPalindrome will iterate through O(N/2) characters in each word where N is the length of the word. By iterating through the characters of each word we set two pointers on the beginning and the end of the string. If the chars are ever not the same, we can conclude that the word is not a palindrome. By returning true, we can increment to the total numberOfPalindromeWords.

2) CalculateNumberOfPalindromeSentences 

3) GetListAndCountOfUniqueWords

4) GetAllWordsFromParagraphContainingInputLetter

The GetInputLetter(), GetInputParagraph(), GetListOfWordsFromString(), and GetListOfSentencesFromString() are all helper functions used for reuseability, intent, and abstraction.
