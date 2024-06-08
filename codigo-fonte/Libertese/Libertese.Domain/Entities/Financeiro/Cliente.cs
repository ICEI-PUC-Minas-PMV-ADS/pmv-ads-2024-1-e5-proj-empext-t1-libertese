﻿namespace Libertese.Domain.Entities.Financeiro
{
    public class Cliente : BaseEntity
    {
        public required string Nome { get; set; }
        public required string? CpfCnpj { get; set; }
        public required string? Telefone { get; set; }
        public required string? Email { get; set; }

    }
}
