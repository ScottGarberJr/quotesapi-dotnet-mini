using Microsoft.EntityFrameworkCore;

namespace QuotesApi.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? Source { get; set; }
        public string? SubSource { get; set; }
        
    }

    class QuotesDb : DbContext
    {
        public QuotesDb(DbContextOptions<QuotesDb> options)
            : base(options) { }

        public DbSet<Quote> Quotes => Set<Quote>();
    }



}