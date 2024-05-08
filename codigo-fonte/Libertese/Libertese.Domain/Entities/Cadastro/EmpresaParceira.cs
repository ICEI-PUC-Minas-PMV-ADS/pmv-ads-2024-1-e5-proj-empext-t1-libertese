namespace Libertese.Domain.Entities.Cadastro
{
    public class EmpresaParceira : BaseEntity
    {
        public required string Nome { get; set; }
        public required string Cnpj { get; set; }
        public required decimal ValorAporte { get; set; }
        public required decimal ValorAdicional { get; set; }
    }
}
