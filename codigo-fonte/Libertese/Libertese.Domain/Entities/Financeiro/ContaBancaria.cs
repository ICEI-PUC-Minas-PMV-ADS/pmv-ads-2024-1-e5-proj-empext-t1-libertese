namespace Libertese.Domain.Entities.Financeiro
{
    public class ContaBancaria : BaseEntity
    {
        public required string Nome { get; set; }
        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? Pix { get; set; }
    }
}
