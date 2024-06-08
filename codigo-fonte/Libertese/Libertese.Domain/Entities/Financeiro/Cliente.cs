using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libertese.Domain.Entities.Financeiro
{
    public class Cliente : BaseEntity
    {
        public required string Nome { get; set; }
        public required string? CpfCnpj { get; set; }
        public required string? Telefone { get; set; }
        public required string? Email { get; set; }

    }
}
