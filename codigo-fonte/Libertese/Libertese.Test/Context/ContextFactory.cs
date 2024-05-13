using Microsoft.EntityFrameworkCore;
using Libertese.Data;

namespace Libertese.Test.Context
{
    public class ContextFactory : ApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = $"Host=silly.db.elephantsql.com;Database=qajmaaza;Username=qajmaaza;Password=Vq-enxrJuqU3XrCL6XB5TxJLVYUxNO_4";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}