using DataAccess.Crud;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Text;


namespace FirstTranslator
{
    class WordManagement
    {

        private WordCrudFactory crudWord;

        public WordManagement()
        {
            crudWord = new WordCrudFactory();
        }

        public void Create(Word word)
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
                }
                else
                {
                    crudWord.Create(word);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

     

        }


        public List<Word> RetrieveAll()
        {
            return crudWord.RetrieveAll<Word>();
        }

        public Word RetrieveById(Word word)
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
