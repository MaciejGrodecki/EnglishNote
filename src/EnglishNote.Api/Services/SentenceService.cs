using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishNote.Api.Domain;
using EnglishNote.Api.Repositories;

namespace EnglishNote.Api.Services
{
    public class SentenceService : ISentenceService
    {
        private readonly ISentenceRepository _sentenceRepository;

        public SentenceService(ISentenceRepository sentenceRepository)
        {
            _sentenceRepository = sentenceRepository;
        }

        public async Task<IEnumerable<Sentence>> BrowseAsync()
            => await Task.FromResult(await _sentenceRepository.BrowseSentencesAsync());

        public async Task<Sentence> GetAsync(Guid sentenceId)
        {
            var sentence = await _sentenceRepository.GetAsync(sentenceId);
            if(sentence == null)
            {
                throw new Exception($"Sentence with {sentenceId} doesn't exist");
            }

            return sentence;
        }


        public async Task AddAsync(string englishSentence, string polishSentence)
        {
            Sentence sentence = new Sentence(Guid.NewGuid(), englishSentence, polishSentence, DateTime.UtcNow);

            await _sentenceRepository.AddAsync(sentence);
        }

        
        public async Task RemoveAsync(Guid sentenceId)
        {
            var sentence = await GetAsync(sentenceId);

            await _sentenceRepository.RemoveAsync(sentence);
        }
    }
}
