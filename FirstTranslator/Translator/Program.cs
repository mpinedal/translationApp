using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities_POJO;
using Translator;

namespace Translator
{
    class Program
    {

        //Test branch

        static Boolean loggedIn = false;

        static void Main(string[] args)
        {


         

            string option = "";

            do
            {
                if (!loggedIn)
                {
                    IntialMenu();
                    option = Console.ReadLine();
                    InitialExcecute(option);
                }
                else
                {
                    ViewMenu();
                    option = Console.ReadLine();
                    Excecute(option);
                }

            }

            while (!option.Equals("0"));
        }

        private static void IntialMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("**************");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("0. Quit app");

        }

        private static void InitialExcecute(string option)
        {
            switch (option)
            {
                case "1":
                    LogIn();
                    break;
                case "2":
                    Register();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;

            }
        }

        private static void LogIn()
        {
            string user;
            string pw;


            Console.WriteLine("");
            Console.WriteLine("Enter username");
            user = Console.ReadLine();

            Console.WriteLine("Enter password");
            pw = Console.ReadLine();

            User loginUser = new User(user, pw);

            var management = new UserManagement();
            string answer = management.LogIn(loginUser);
            if (answer.Equals("loggedIn"))
            {
                loggedIn = true;
            }
            else
            {
                Console.WriteLine("Invalid credentials");
            }


        }

        private static void Register()
        {
            string user;
            string pw;


            Console.WriteLine("");
            Console.WriteLine("Enter username");
            user = Console.ReadLine();

            Console.WriteLine("Enter password");
            pw = Console.ReadLine();

            User newUser = new User(user, pw);

            var management = new UserManagement();
            string answer = management.Create(newUser);
            if (answer.Equals("Success"))
            {
                Console.WriteLine("You have been registered");
            }
            else
            {
                Console.WriteLine("User already exists");
            }



        }

        private static void ViewMenu()
        {
           
            Console.WriteLine("");
            Console.Write("Hello ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{UserManagement.login.UserName}");
            Console.ResetColor();
            Console.WriteLine("!");
            Console.WriteLine("**************");
            Console.WriteLine("1. Language list");
            Console.WriteLine("2. Translate");
            Console.WriteLine("3. Calculate popularity");
            Console.WriteLine("4. List records");
            Console.WriteLine("!. Log out");
        }

        private static void Excecute(string option)
        {

            switch (option)
            {

                case "1":
                    ShowLanguages();
                    break;

                case "2":

                    GetData("Translate");
                    break;

                case "3":
                    GetData("Popularity");
                    break;

                case "4":
                    ListRecords();
                    break;
                case "!":
                    loggedIn = false;
                    break;



            }
        }

  

        private static string GetData(string action)
        {
            List<string> languages = GetLanguages();


            //Source
            Console.WriteLine("**** Type: '!' to go back");
            Console.WriteLine("Enter the source language");
            string source = Console.ReadLine().ToLower();
            if (source.Equals("!"))
            {
                return "break";
            }
            else if (!languages.Contains(source))
            {
                Console.WriteLine("We don't have that language in our database!");
                Console.WriteLine("Would you like to add it? YES/NO");
                string answer = Console.ReadLine().ToLower();
                if (answer.Equals("no") || answer.Equals("!"))
                {
                    return "break";
                }
            }


            //Target
            Console.WriteLine("Enter the target language");
            string target = Console.ReadLine().ToLower();

            if (target.Equals("!"))
            {
                return "break";
            }
            else if (!languages.Contains(target))
            {
                Console.WriteLine("We don't have that language in our database!");
                Console.WriteLine("Would you like to add it? YES/NO");
                string answer = Console.ReadLine().ToLower();
                if (answer.Equals("no") || answer.Equals("!"))
                {
                    return "break";
                }
            }

            Console.WriteLine("Please insert the word or phrase");
            string text = Console.ReadLine().ToLower();

            if (text.Equals("!"))
            {
                return "break";
            }

            switch (action)
            {
                case "Popularity":
                    int popularity = GetPoupularity(text, source, target);
                    PrintPopularity(text, popularity);
                    break;

                case "Translate":
                    TranslateText(text, source, target);
                    break;
            }

            



            return "break";

        
        }

        private static List<string> ShowLanguages()
        {
            Console.WriteLine("Languages....");

            List<string> languagesList = new List<string>();
            var management = new WordManagement();

            var wordList = management.RetrieveAll();
            foreach (Word element in wordList)
            {
                languagesList.Add(element.Source);
                languagesList.Add(element.Target);
            }

            var uniqueLanguages = languagesList.Distinct();


            foreach (string element in uniqueLanguages)
            {
                Console.WriteLine(element);
            }

            var unique = uniqueLanguages.ToList();
            return unique;


        }

        private static List<string> GetLanguages()
        {


            List<string> languagesList = new List<string>();
            var management = new WordManagement();

            var wordList = management.RetrieveAll();
            foreach (Word element in wordList)
            {
                languagesList.Add(element.Source);
                languagesList.Add(element.Target);
            }

            var uniqueLanguages = languagesList.Distinct();
            var unique = uniqueLanguages.ToList();

            return unique;


        }

        public static void TranslateText(string text, string source, string target)
        {
            var wordArray = text.Split(' ');

            string translatedText = "";

            var management = new WordManagement();
  

            for (int i = 0; i < wordArray.Length; i++)
            {
                var word = new Word(wordArray[i], source, target);
                string result = management.UpdateQuantity(word);
                if (!result.Equals("word does not exist"))
                {
                    //Word does exist in database
                    translatedText += result + " ";
                }
                else if (result.Equals("word does not exist"))
                {
                    Console.WriteLine($"We dont have the translation for: {wordArray[i]} ");
                    Console.WriteLine($"Please provide a translation ");
                    string translation = Console.ReadLine();
                    word.Translation = translation;
                    Console.WriteLine($"Thank you ");
                    management.PowerCreate(word);
                    //
                  
                    translatedText += translation + " ";
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(translatedText);
                Console.ResetColor();

            }

            //*****************Add record*************

            //Get popularity
            int popularity = GetPoupularity(text, source, target);


            
            var recordManagement = new RecordManagement();
            Record newRecord = new Record(text, source, target, popularity, UserManagement.login.UserName, translatedText);
            recordManagement.Create(newRecord);
            //*****************************************


        }

        public static int GetPoupularity(string text, string source, string target)
        {
            var wordArray = text.Split(' ');
            int popularity = 0;

            var management = new WordManagement();
            var wordList = management.RetrieveAll();

            for (int i = 0; i < wordArray.Length; i++)
            {
                var word = new Word(wordArray[i], source, target);
                string result = management.Check(word);
                if (!result.Equals("word does not exist"))
                {
                    word = management.RetrieveByWord(word);
                    popularity += word.Quantity;
                }
                else if (result.Equals("word does not exist"))
                {
                    popularity += 0;
                }

            }

            return popularity;

        }

        private static void PrintPopularity(string text, int popularity)
        {
            var wordArray = text.Split(' ');

            Console.ForegroundColor = ConsoleColor.Green;
            if (wordArray.Length == 1)
            {
                Console.WriteLine($"Word popularity: {popularity}");
            }
            else
            {
                Console.WriteLine($"Phrase popularity: {popularity}");
            }
            Console.ResetColor();

        }

        private static void ListRecords()
        {
            var management = new RecordManagement();
            List<Record> records = management.RetrieveAll();

            foreach(Record element in records)
            {
                Console.WriteLine(element.ToString());
            }

        }
    }
}
