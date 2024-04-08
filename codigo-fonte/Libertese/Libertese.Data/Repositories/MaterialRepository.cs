using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Precificacao;
using Microsoft.EntityFrameworkCore;

namespace Libertese.Data.Repositories
{
    public class MaterialRepository : IMaterialRepository<Material>
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
           _context = context;
        }

        public async Task<Material> Create(Material material)
        {
            await _context.Materiais.AddAsync(material);
            await _context.SaveChangesAsync();
            return material;   
        }

        public async Task<List<Material>> GetAll()
        {
            return await _context.Materiais.ToListAsync();
        }

        public async Task<Material> GetById(int id) 
        {
            var existingMaterial = await _context.Materiais.FindAsync(id);

            if (existingMaterial == null)
            {
                throw new KeyNotFoundException("Material não encontrado.");
            }
            else
            {
                return existingMaterial;
            }

        }

        public async Task<Material> Update(Material material)
        {
            var existingMaterial = await _context.Materiais.FindAsync(material.Id);
      
            if (existingMaterial == null)
            {
                throw new KeyNotFoundException("Material não encontrado.");
            } else
            {
                _context.Entry(existingMaterial).CurrentValues.SetValues(material);
                await _context.SaveChangesAsync();
                return existingMaterial;
            }
        }

        public async Task<Material> Delete(int id)
        {
            var existingMaterial = await _context.Materiais.FindAsync(id);

            if (existingMaterial == null)
            {
                throw new KeyNotFoundException("Material não encontrado.");
            }
            else
            {
                _context.Materiais.Remove(existingMaterial);
                await _context.SaveChangesAsync();
                return existingMaterial;
            }
        }
    }
}
