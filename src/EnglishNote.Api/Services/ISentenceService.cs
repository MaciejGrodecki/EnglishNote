using EnglishNote.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishNote.Api.Services
{
    public interface ISentenceService
    {
        Task<IEnumerable<Sentence>> BrowseAsync();
        Task<Sentence> GetAsync(Guid sentenceId);
        Task AddAsync(string englishSentence, string polishSentence);
        Task RemoveAsync(Guid sentenceId);
    }
}
