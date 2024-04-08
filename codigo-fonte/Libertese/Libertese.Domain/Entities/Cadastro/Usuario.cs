namespace Libertese.Domain.Entities.Cadastro
{
    public class Usuario : BaseEntity
    {
        public Usuario(string Nome, string Email, string Senha)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
        }

        public int PermissaoID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
