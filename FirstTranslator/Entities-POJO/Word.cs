﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Word : BaseEntity
    {

        public string GUID { get; set; }
        public string TranslatedWord { get; set; }
        public int Quantity { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }


        public Word()
        {   

        }

        public Word(string translatedWord)
        {

            Guid newGuid = Guid.NewGuid();
            GUID = newGuid.ToString();
            TranslatedWord = translatedWord;
            Quantity = 1;

        }

        public Word(string translatedWord, string source, string target)
        {

            Guid newGuid = Guid.NewGuid();
            GUID = newGuid.ToString();
            TranslatedWord = translatedWord;
            Source = source;
            Target = target;
            Quantity = 1;

        }

    }
}
