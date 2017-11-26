using EnglishNote.Api.Domain;
using EnglishNote.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace EnglishNote.Api.SQLite
{
    public class DatabaseContext : DbContext
    {
        private SQLiteSettings _sqlLiteSettings;

        public DbSet<Sentence> Senteces { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IOptions<SQLiteSettings> sqlLiteSettings)
            : base(options)
        {
            
            _sqlLiteSettings = sqlLiteSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_sqlLiteSettings.ConnectionString);
        }
    }
}
