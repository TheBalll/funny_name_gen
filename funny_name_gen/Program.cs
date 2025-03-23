using System;
using System.Collections.Generic;


namespace funny_name_gen
{
    public class FunnyNameGenerator
    {
        static Random random = new Random();

        
        static string[] baseNames = { "Denis", "Georgi", "Ali" };

        
        static string[] funnyWords = { "roshko", "dingleberry", "asfalt", "kopcheto", "chernata dupka", "Snickers", "my left nut", "kosmat", "bezkosmest", "etiketa" };

        
        static string[] races = { "the black", "chiness", "negro", "white", "vasko" ,"ching chong","french trash"};
        static string[] heights = { "Short", "giga short", "ali baba", "Gigantic", "tall" ,"tree",};
        static string[] weights = { "ali baba", "debel", "klechka", "average", "festivly plump","bare bones","big boned" };
        static string[] appearances = { "na 3 rakii", "homeless", "bald", "drippy", "tuff", "nadrusan", "izpran ot toka", "Angel","nedospan", "stabilen" };
        static string[] moods = {"Hyper Active", "Chill", "Mischievous", "Sad", "Angry" };

        
        public static string GenerateRandomWord(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength + 1); 
            char[] chars = new char[length];

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
             bool running = true;

 
 while (running)
 {
     Console.Clear();
     Console.WriteLine("Welcome to the Funny Name Generator!");
     Console.WriteLine("1. Start generating names");
     Console.WriteLine("2. Exit");
     Console.Write("Please enter your choice (1 or 2): ");
     string userChoice = Console.ReadLine();

     switch (userChoice)
     {
         case "1":
             Console.Write("Enter how many names you want to generate: ");
             int count;
             if (int.TryParse(Console.ReadLine(), out count))
             {
                 GenerateNames(count);
             }
             else
             {
                 Console.WriteLine("Invalid input for the number of names. Please enter a valid number.");
             }
             break;

         case "2":
             Console.WriteLine("Exiting... Goodbye!");
             running = false;
             break;

         default:
             Console.WriteLine("Invalid choice! Please enter 1 or 2.");
             break;
     }

     
     Console.WriteLine("Press ENTER to continue...");
     Console.ReadLine(); 
 }
        }
    }
}
