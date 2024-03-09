namespace Libertese.Domain.Entities.Cadastro
{
    public class Funcionario : BaseEntity
    {

        public required string Nome { get; set; }

        public required int HorasDia { get; set; }

        public required int DiasMes { get; set; }

        public required Boolean Remuneracao { get; set; }

        public required decimal Salario { get; set; }

    }
}
