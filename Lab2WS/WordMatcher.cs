using System;
using System.Collections.Generic;

namespace Lab2WS
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                        Char[] scramble = scrambledWord.ToCharArray();
                        Char[] charword = word.ToCharArray();
                        Array.Sort(scramble);
                        Array.Sort(charword);
                        scramble.ToString();
                        charword.ToString();

                        if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                        }
                        else
                        {

                        }
                    }

                }
            }

            return null;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}
