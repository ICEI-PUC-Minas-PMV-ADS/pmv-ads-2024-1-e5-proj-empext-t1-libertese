using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Por favor, insira um CPF válido no formato XXX.XXX.XXX-XX.")]
        public required string Cpf {  get; set; }

        public required string Sexo { get; set; }

        public required string Email { get; set; }

        [Required(ErrorMessage = "O número de celular é obrigatório.")]
        [RegularExpression(@"^(\d{0,2})(\d{0,5})(\d{0,4})$", ErrorMessage = "Por favor, insira um número de celular válido no formato (XX) XXXXX-XXXX")]
        public required string Celular { get; set; }

        public required string Function { get; set; }

        public required string Penitenciaria { get; set; }

        public required Boolean CursoLibertese { get; set; }

        public required Boolean Pessoareclusa { get; set; }


    }
}
