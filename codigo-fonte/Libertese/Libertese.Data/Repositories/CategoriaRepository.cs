using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Precificacao;
using Microsoft.EntityFrameworkCore;

namespace Libertese.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository<Categoria>
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;   
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetById(int id) 
        {
            var existingCategoria = await _context.Categorias.FindAsync(id);

            if (existingCategoria == null)
            {
                throw new KeyNotFoundException("Categoria não encontrada.");
            }
            else
            {
                return existingCategoria;
            }

        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            var existingCategoria = await _context.Categorias.FindAsync(categoria.Id);
      
            if (existingCategoria == null)
            {
                throw new KeyNotFoundException("Categoria não encontrada.");
            } else
            {
                existingCategoria.DataAtualizacao = DateTime.Now;
                existingCategoria.Nome = categoria.Nome;
                _context.Update(existingCategoria);
                await _context.SaveChangesAsync();
                return existingCategoria;
            }
        }

        public async Task<Categoria> Delete(int id)
        {
            var existingCategoria = await _context.Categorias.FindAsync(id);

            if (existingCategoria == null)
            {
                throw new KeyNotFoundException("Categoria não encontrada.");
            }
            else
            {
                _context.Categorias.Remove(existingCategoria);
                await _context.SaveChangesAsync();
                return existingCategoria;
            }
        }
    }
}
