namespace Libertese.Domain.Entities.Financeiro
{
    public class Fornecedor : BaseEntity
    {
        public required string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? DadosBancarios { get; set; }
    }
}
