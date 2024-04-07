using Libertese.Model;
using System.Collections.Generic;
using System.Linq;

namespace Libertese.Infraestrutura
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

        public User GetByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}
