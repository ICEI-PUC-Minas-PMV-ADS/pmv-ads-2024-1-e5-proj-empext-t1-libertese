using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libertese_PrimeiroAcesso.Model
{
    [Table("Usuarios")]
    public class User
    {
        [Key]
        public int Id { get; private set; }
        public int PermissaoID { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao{ get; private set; }

        public User(string Nome, string Email, string Senha)
        {
            this.Nome = Nome ?? throw new ArgumentNullException(nameof(Nome));
            this.Email = Email;
            this.Senha = Senha;
            this.DataCriacao = DateTime.UtcNow;
        }
    }
}
