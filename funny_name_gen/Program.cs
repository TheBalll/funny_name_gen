﻿using System;
using System.Collections.Generic;


namespace funny_name_gen
{
    public class FunnyNameGenerator
    {
        static Random random = new Random();

        
        static string[] baseNames = { "Denis", "Georgi", "Ali" };

        
        static string[] funnyWords = { "roshko", "dingleberry", "asfalt", "kopcheto", "chernata_dupka", "Snickers", "my left nut", "kosmat", "bezkosmest", "etiketa" };

        
        static string[] races = { "the black", "chiness", "negro", "white", "vasko" ,"ching chong","french trash"};
        static string[] heights = { "Short", "giga short", "ali baba", "Gigantic", "tall" ,"tree",};
        static string[] weights = { "ali baba", "debel", "klechka", "average", "festivly plump","bones","big boned" };
        static string[] appearances = { "Bearded", "homeless", "Bald", "drippy", "Moustached", "angal" };
        static string[] moods = { "Jolly", "Grumpy", "Hyper", "Chill", "Mischievous", "Sad", "Angry" };

        
        public static string GenerateRandomWord(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength + 1); 
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)random.Next('a', 'z' + 1);
            }

            return new string(chars);
        }

        
        public static string GenerateFunnyName()
        {
            
            int numberOfWords = random.Next(3, 5);

            
            HashSet<string> usedWords = new HashSet<string>();

            
            List<string> nameParts = new List<string>();

            
            string funnyWord = funnyWords[random.Next(funnyWords.Length)];
            nameParts.Add(funnyWord);
            usedWords.Add(funnyWord);

            
            bool anchorNameAdded = false;

            
            while (nameParts.Count < numberOfWords)
            {
                
                int option = random.Next(6);
                string newWord = "";

                switch (option)
                {
                    case 0: 
                        if (!anchorNameAdded)
                        {
                            newWord = baseNames[random.Next(baseNames.Length)];
                            anchorNameAdded = true;
                        }
                        break;
                    case 1: 
                        newWord = races[random.Next(races.Length)];
                        break;
                    case 2: 
                        newWord = heights[random.Next(heights.Length)];
                        break;
                    case 3:
                        newWord = weights[random.Next(weights.Length)];
                        break;
                    case 4:
                        newWord = appearances[random.Next(appearances.Length)];
                        break;
                    case 5: 
                        newWord = moods[random.Next(moods.Length)];
                        break;
                }

                
                if (!usedWords.Contains(newWord))
                {
                    nameParts.Add(newWord);
                    usedWords.Add(newWord);
                }
            }

            
            if (!anchorNameAdded)
            {
                string forcedAnchor = baseNames[random.Next(baseNames.Length)];
                nameParts.Insert(random.Next(nameParts.Count), forcedAnchor); 
            }

            
            return string.Join(" ", nameParts);
        }

        
        public static void GenerateNames(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string funnyName = GenerateFunnyName();
                Console.WriteLine($"Generated funny name {i + 1}: {funnyName}");
            }
        }

        public static void Main(string[] args)
        {
            
            Console.Write("Enter how many names you want to generate: ");
            int count = int.Parse(Console.ReadLine());

            
            GenerateNames(count);
        }
    }
}
