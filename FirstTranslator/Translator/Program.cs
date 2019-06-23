using System;
using Google.Cloud.Translation.V2;

using Google.Apis.Auth.OAuth2;
using Entities_POJO;

namespace FirstTranslator
{
    class Program
    {
        private const string path = @"C:\Users\milton\source\repos\FirstTranslator\JSON\Sicen-722f8698c05e.json";

 

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
                    showLangueges();
                    break;
                case "2":
                    Console.WriteLine("**** Type: '!' to go back");
                    Console.WriteLine("Enter the source language code");
                    string source = Console.ReadLine();
                    if (source.Equals("!"))
                    {
                        break;
                    }

                    Console.WriteLine("Enter the target language code");
                    string target = Console.ReadLine();

                    if ( target.Equals("!") )
                    {
                        break;
                    }
                    Console.WriteLine("Please insert the text you wish to translate");
                    string text = Console.ReadLine();

                    if (text.Equals("!"))
                    {
                        break;
                    }

                    TranslateText(source, target, text);

                    var management = new WordManagement();

                    var wordArray = text.Split(' ');

                    for (int i = 0; i < wordArray.Length; i++)
                    {
                        var word = new Word(wordArray[i]);
                        management.Create(word);

                    }


                    break;



            }
        }

        private static void showLangueges()
        {
            Console.WriteLine("Languages....");

            string jsonPath = path;
            var credential = GoogleCredential.FromFile(jsonPath);
            //var storage = TranslationClient.Create(credential);
            TranslationClient client = TranslationClient.Create(credential);

            foreach (var language in client.ListLanguages(LanguageCodes.English))
            {
                Console.WriteLine($"{language.Code}\t{language.Name}");
            }
        }

        private static void ViewMenu()
        {
            Console.WriteLine("**************");
            Console.WriteLine("1. Language list");
            Console.WriteLine("2. Translate");
            Console.WriteLine("0. Quit");
        }

        public static string TranslateText(string source, string target, string text)
        {

            try
            {
                string jsonPath = path;
                var credential = GoogleCredential.FromFile(jsonPath);
                //var storage = TranslationClient.Create(credential);
                TranslationClient client = TranslationClient.Create(credential);
                var response = client.TranslateText(
                    text: text,
                    targetLanguage: target,
                    sourceLanguage: source);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(response.TranslatedText);
                Console.ResetColor();
                return response.TranslatedText;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid language code!!");
                Console.WriteLine("Make sure to check the list");
                return null;
            }
        }
    }
}
