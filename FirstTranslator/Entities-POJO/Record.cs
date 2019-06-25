using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Record : BaseEntity
    {

        public string GUID { get; set; }
        public string Date {get; set;}
        public string Source { get; set; }
        public string Target { get; set; }
        public string OriginalPhrase { get; set; }
        public string Translation { get; set; }
        public int Popularity { get; set; }
        public string User { get; set; }

        public Record()
        {

        }


        public Record(string originalPhrase, string source, string target, int popularity, string userName, string translation)
        {
            Guid newGuid = Guid.NewGuid();
            GUID = newGuid.ToString();
            Date = DateTime.Now.ToString("MM / dd / yyyy HH: mm:ss");
            Source = source;
            Target = target;
            OriginalPhrase = originalPhrase;
            Popularity = popularity;
            User = userName;
            Translation = translation;
        }

        public override string ToString()
        {
            return $"Date: {Date}, User: {User}, Source language: {Source}, Phrase: {OriginalPhrase}, Target languge: {Target}, Translation: {Translation}, Popularity: {Popularity}";
        }

    }
}
