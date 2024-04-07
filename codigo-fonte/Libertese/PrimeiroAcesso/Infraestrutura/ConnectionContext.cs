using PrimeiroAcesso.Model;
using Microsoft.EntityFrameworkCore;

namespace PrimeiroAcesso.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
            "Server=kesavan.db.elephantsql.com;" +
            "Port=5432;Database=vmmnsskv;" +
            "User Id=vmmnsskv;" +
            "Password=ltCFu-1_rlWnVDnqMC7vwS-fEQDKxmBa;");//Conexão do banco de dados

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DataCriacao)
                .HasDefaultValueSql("NOW()"); // Define o valor padrão para DataCriacao como a data e hora atuais no banco de dados
        }
    }
}
