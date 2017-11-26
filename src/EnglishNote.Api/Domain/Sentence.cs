using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishNote.Api.Domain
{
    public class Sentence
    {
        public Guid SentenceId { get; protected set; }
        public string EnglishSentence { get; protected set; }
        public string PolishSentence { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

        protected Sentence()
        {

        }

        public Sentence(Guid sentenceId, string englishSentence, string polishSentence,
            DateTime createdDate)
        {
            SentenceId = sentenceId;
            SetEnglishSentence(englishSentence);
            SetPolishSentence(polishSentence);
            CreatedDate = createdDate;
        }

        private void SetPolishSentence(string polishSentence)
        {
            if (String.IsNullOrWhiteSpace(polishSentence))
            {
                throw new Exception("Wyrażenie jest puste");
            }

            PolishSentence = polishSentence;
        }

        private void SetEnglishSentence(string englishSentence)
        {
            if (String.IsNullOrWhiteSpace(englishSentence))
            {
                throw new Exception("Wyrażenie jest puste");
            }

            EnglishSentence = englishSentence;
        }
    }
}
