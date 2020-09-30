using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                Boolean condition = false;

                do
                {
                    Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                    string option = Console.ReadLine() ?? throw new Exception("String is null");
                
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter the full path and filename >");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) separated by a comma");
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized. Please try again.");
                            condition = true;
                            break;
                    }
                } while (condition);

            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry an error has occurred.. " + e.Message);
            }

        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            String scrambled = Console.ReadLine();
            String[] scrambledWords = scrambled.Split(',');
            DisplayMatchedScrambledWords(scrambledWords);

        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(ConstantsFile.WordList);

            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords==null)
            {
                Console.WriteLine("No words found.");
            }
            else
            {
                foreach (MatchedWord s in matchedWords)
                {
                    Console.WriteLine("Words {0} and {1} match", s.ScrambledWord, s.Word);
                }
            }
        }
    }
}
