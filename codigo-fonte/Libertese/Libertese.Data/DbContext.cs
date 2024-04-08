using Libertese.Domain.Entities;
using Libertese.Domain.Entities.Cadastro;
using Libertese.Domain.Entities.ControleAcesso;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Domain.Entities.Venda;
using Microsoft.EntityFrameworkCore;

namespace Libertese.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base(GetOptions("Host=kesavan.db.elephantsql.com;Database=vmmnsskv;Username=vmmnsskv;Password=ltCFu-1_rlWnVDnqMC7vwS-fEQDKxmBa"))
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #region Precificacao
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<ProdutoMaterial> ProdutoMaterial { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CapacidadeProdutiva> CapacidadeProdutivas { get; set; }
        public DbSet<Preco> Precos { get; set; }
        public DbSet<Rateio> Rateios { get; set; }
        #endregion

        #region Cadastros
        public DbSet<EmpresaParceira> EmpresasParceiras { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        #region ControleAcesso
        public DbSet<Permissao> Permissoes { get; set; }
        #endregion

        #region Financeiro
        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Receita> Receitas { get; set; }
        #endregion

        #region Venda
        public DbSet<Venda> Vendas { get; set; }
        #endregion


        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DataCriacao = now;
                }
                if(entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).DataAtualizacao = now;
                }
                
            }
        }
    }
}
