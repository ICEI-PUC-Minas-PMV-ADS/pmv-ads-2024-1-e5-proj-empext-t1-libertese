using Libertese_PrimeiroAcesso.Model;
using Microsoft.EntityFrameworkCore;

namespace Libertese_PrimeiroAcesso.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
            "Server=kesavan.db.elephantsql.com;" +
            "Port=5432;Database=vmmnsskv;" +
            "User Id=vmmnsskv;" +
            "Password=ltCFu-1_rlWnVDnqMC7vwS-fEQDKxmBa;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DataCriacao)
                .HasDefaultValueSql("NOW()"); // Define o valor padrão para DataCriacao como a data e hora atuais no banco de dados
        }
    }
}
