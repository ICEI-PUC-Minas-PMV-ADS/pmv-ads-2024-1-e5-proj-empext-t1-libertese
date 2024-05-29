namespace Libertese.Domain.Entities.Financeiro
{
    public class FornecedorDTO : BaseEntity
    {
        public required string Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Cpf { get; set; }
        public required string Cnpj { get; set; }
        public string? Telefone { get; set; }
        public string? TelefoneDois { get; set; }
        public string? Email { get; set; }
        public int DadosBancariosId { get; set; }
        public required string MaterialFornecido { get; set; }
    }
}
