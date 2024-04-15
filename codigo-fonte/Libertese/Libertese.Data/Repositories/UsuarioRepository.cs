using Libertese.Data.Repositories.Interfaces;
using Libertese.Domain.Entities.Cadastro;

namespace Libertese.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

    }
}
