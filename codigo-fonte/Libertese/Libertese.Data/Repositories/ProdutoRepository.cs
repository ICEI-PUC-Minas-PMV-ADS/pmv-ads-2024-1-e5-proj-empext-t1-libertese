using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Precificacao;
using Microsoft.EntityFrameworkCore;

namespace Libertese.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository<Produto>
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
            return produto;   
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> GetById(int id) 
        {
            var existingProduto = await _context.Produtos.FindAsync(id);

            if (existingProduto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }
            else
            {
                return existingProduto;
            }

        }

        public async Task<Produto> Update(Produto produto)
        {
            var existingProduto = await _context.Produtos.FindAsync(produto.Id);
      
            if (existingProduto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            } else
            {
                _context.Entry(existingProduto).CurrentValues.SetValues(produto);
                await _context.SaveChangesAsync();
                return existingProduto;
            }
        }

        public async Task<Produto> Delete(int id)
        {
            var existingProduto = await _context.Produtos.FindAsync(id);

            if (existingProduto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }
            else
            {
                _context.Produtos.Remove(existingProduto);
                await _context.SaveChangesAsync();
                return existingProduto;
            }
        }
    }
}
