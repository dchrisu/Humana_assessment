Hello all those viewing. This is my solution to the Coding Assessment provided. Please note, that given for the solution 

1) CalculateNumberOfPalindromeWords will iterate through each list of words from the paragraph and check if the current word is a palindrome. If we encounter a palindrome word, we increment our numberOfPalindromeWords variable and then return that number.

2) CalculateNumberOfPalindromeSentences will iterate through each list of sentences from the paragraph and then will iterate through each list of words in the current sentence. On that current sentence, we will see if the sentence is a palindrome by checking the words using a leading and ending pointer. If the current sentence contains a palindrome, incrememnt the numberOfPalindromeSentences variable and then return that number.

3) GetListAndCountOfUniqueWords

4) GetAllWordsFromParagraphContainingInputLetter
    - With M being the number of words in the paragraph (from GetListOfWordsFromString)
    - With P being the number of characters in the paragraph string (from string.Split())
    - O(M) time complexity 
    - O(P) space complexity 

The CheckIfWordIsPalindrome(), GetInputLetter(), GetInputParagraph(), GetListOfWordsFromString(), and GetListOfSentencesFromString() are all helper functions used for reuseability, intent, and abstraction.
