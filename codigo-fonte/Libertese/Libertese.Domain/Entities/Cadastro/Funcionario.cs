using System.Diagnostics.CodeAnalysis;

namespace Libertese.Domain.Entities.Cadastro
{
    public class Funcionario : BaseEntity
    {

        public required string Nome { get; set; }

        public required int HorasDia { get; set; }

        public required int DiasMes { get; set; }

        public required Boolean Remuneracao { get; set; }

        public required decimal Salario { get; set; }

        public required string Cpf {  get; set; }

        public required string Sexo { get; set; }

        public required string Email { get; set; }

        public required string Celular { get; set; }

        public required string Function { get; set; }

        public required string Penitenciaria { get; set; }

        public required Boolean CursoLibertese { get; set; }

        public required Boolean Pessoareclusa { get; set; }


    }
}
