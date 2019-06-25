using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Text;


namespace Translator
{
    class WordManagement
    {

        private WordCrudFactory crudWord;

        public WordManagement()
        {
            crudWord = new WordCrudFactory();
        }

        public void PowerCreate(Word word)
        {
            crudWord.Create(word);
        }


        public string UpdateQuantity(Word word)
        {

            try
            {
                var w = crudWord.Retrieve<Word>(word);
                if (w != null)
                {
                    //Word alreay exists
                    //We should add 1 to the quantity
                    w.Quantity = w.Quantity + 1;
                    crudWord.Update(w);
                    return w.Translation;
                }
                else
                {
                    //word does not exist, we must ask for translation
                    return "word does not exist";
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }


            return null;
        }

        public string Check(Word word)
        {

       
                var w = crudWord.Retrieve<Word>(word);
                if (w != null)
                {
                    //Word alreay exists
                    return w.Translation;
                }
                else
                {
                    //word does not exist
                    return "word does not exist";
                }

            
      

    
        }


        public List<Word> RetrieveAll()
        {
            return crudWord.RetrieveAll<Word>();
        }

        public Word RetrieveByWord(Word word)
        {
            return crudWord.Retrieve<Word>(word);
        }

        internal void Update(Word word)
        {
            crudWord.Update(word);
        }

        internal void Delete(Word word)
        {
            crudWord.Delete(word);
        }

    }
}
