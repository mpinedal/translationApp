using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entities_POJO;

namespace FirstTranslator
{
    class Program
    {

        //Test branch


        static void Main(string[] args)
        {


            Console.WriteLine("Hello user!");

            string option = "";

            do
            {
                ViewMenu();
                option = Console.ReadLine();
                Excecute(option);

            }

            while (!option.Equals("0"));




        }

        private static void Excecute(string option)
        {

            switch (option)
            {

                case "1":
                    ShowLanguages();
                    break;
                case "2":
                    List<string> languages = GetLanguages();


                    //Source
                    Console.WriteLine("**** Type: '!' to go back");
                    Console.WriteLine("Enter the source language");
                    string source = Console.ReadLine().ToLower();
                    if (source.Equals("!"))
                    {
                        break;
                    }
                    else if (!languages.Contains(source))
                    {
                        Console.WriteLine("We don't have that language in our database!");
                        Console.WriteLine("Would you like to add it? YES/NO");
                        string answer = Console.ReadLine().ToLower();
                        if (answer.Equals("no") || answer.Equals("!"))
                        {
                            break;
                        }
                    }


                    //Target
                    Console.WriteLine("Enter the target language");
                    string target = Console.ReadLine().ToLower();

                    if ( target.Equals("!") )
                    {
                        break;
                    }
                    else if (!languages.Contains(target))
                    {
                        Console.WriteLine("We don't have that language in our database!");
                        Console.WriteLine("Would you like to add it? YES/NO");
                        string answer = Console.ReadLine().ToLower();
                        if (answer.Equals("no") || answer.Equals("!"))
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Please insert the text you wish to translate");
                    string text = Console.ReadLine().ToLower();

                    if (text.Equals("!"))
                    {
                        break;
                    }



                    var wordArray = text.Split(' ');
                    TranslateText(wordArray, source, target);



                    break;



            }
        }

        private static List<string> ShowLanguages()
        {
            Console.WriteLine("Languages....");

            List<string> languagesList = new List<string>();
            var management = new WordManagement();

            var wordList = management.RetrieveAll();
        foreach(Word element in wordList)
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

        private static void ViewMenu()
        {
            Console.WriteLine("**************");
            Console.WriteLine("1. Language list");
            Console.WriteLine("2. Translate");
            Console.WriteLine("0. Quit");
        }

        public static void TranslateText(string[] wordArray, string source, string target)
        {
            string tranlatedText = "";

            var management = new WordManagement();

            for (int i = 0; i < wordArray.Length; i++)
            {
                var word = new Word(wordArray[i], source, target);
                string result = management.Create(word);
                if (!result.Equals("word does not exist"))
                {
                    tranlatedText += result + " ";
                }
                else if (result.Equals("word does not exist"))
                {
                    Console.WriteLine($"We dont have the translation for: {wordArray[i]} ");
                    Console.WriteLine($"Please provide a translation ");
                    string translation = Console.ReadLine();
                    word.Translation = translation;
                    Console.WriteLine($"Thank you ");
                    management.PowerCreate(word);
                    tranlatedText += translation + " ";
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(tranlatedText);
                Console.ResetColor();

            }





        }
    }
}
