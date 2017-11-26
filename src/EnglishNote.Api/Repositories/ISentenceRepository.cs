using EnglishNote.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishNote.Api.Repositories
{
    public interface ISentenceRepository
    {
        Task<IEnumerable<Sentence>> BrowseSentencesAsync();
        Task<Sentence> GetAsync(Guid sentenceId);
        Task AddAsync(Sentence sentence);
        Task RemoveAsync(Sentence sentence);
    }
}
