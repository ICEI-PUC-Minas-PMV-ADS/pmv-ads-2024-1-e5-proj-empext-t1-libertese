namespace Libertese.Domain.Entities.Cadastro
{
    public class Usuario : BaseEntity
    {
        public required int PermissaoID { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string Senha { get; set; }
    }
}
