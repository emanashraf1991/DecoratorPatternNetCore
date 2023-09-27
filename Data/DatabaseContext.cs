using DecoratorPatternNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPatternNetCore.Data{
    public class DatabaseContext : DbContext{
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        public DbSet<Member> Members { get; set; }
    }
}