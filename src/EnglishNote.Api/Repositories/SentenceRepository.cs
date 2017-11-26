using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishNote.Api.Domain;
using EnglishNote.Api.SQLite;
using Microsoft.EntityFrameworkCore;

namespace EnglishNote.Api.Repositories
{
    public class SentenceRepository : ISentenceRepository
    {
        private DatabaseContext _context;

        public SentenceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sentence>> BrowseSentencesAsync()
            => await Task.FromResult(_context.Senteces);

        public async Task<Sentence> GetAsync(Guid sentenceId)
        {
            var sentence = await _context.Senteces.SingleOrDefaultAsync(x => x.SentenceId == sentenceId);

            return sentence;
        }

        public async Task AddAsync(Sentence sentence)
        {
            await _context.AddAsync(sentence);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Sentence sentence)
        {
            _context.Remove(sentence);
            await _context.SaveChangesAsync();
        }
    }
}
