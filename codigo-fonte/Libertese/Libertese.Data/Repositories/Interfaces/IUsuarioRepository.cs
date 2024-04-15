using Libertese.Domain.Entities.Cadastro;

namespace Libertese.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);

        List<Usuario> Get();

        Usuario GetByEmail(string email);
    }
}
