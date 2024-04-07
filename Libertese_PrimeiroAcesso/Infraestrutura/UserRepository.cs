using Libertese_PrimeiroAcesso.Model;

namespace Libertese_PrimeiroAcesso.Infraestrutura
{
    public class UserRepository : IUserRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(User user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public List<User> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}
