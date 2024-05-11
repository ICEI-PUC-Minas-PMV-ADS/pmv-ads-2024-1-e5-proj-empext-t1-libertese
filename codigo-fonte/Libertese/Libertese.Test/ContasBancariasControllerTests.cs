using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Test.Context;
using Libertese.Web.Controllers.Financeiro;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data.Entity;

namespace Libertese.Test
{
    [TestFixture]
    public class ContasBancariasControllerTests
    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private ContaBancariasController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new ContaBancariasController(_context);
        }

        [Test]
        public async Task TestCriarContaBancaria() 
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var contaBancaria =  new ContaBancaria { Nome = "Itaú", Agencia = "120", Conta = "800-10"};

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(contaBancaria);
            var contaBancariaCriada = _context.ContasBancarias.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(contaBancariaCriada, "conta bancária não foi criada no banco de dados");    
            Assert.That(contaBancaria.Agencia, Is.EqualTo(contaBancariaCriada.Agencia));
            Assert.That(contaBancaria.Conta, Is.EqualTo(contaBancariaCriada.Conta));

        }

        [Test]
        public async Task TestEditarContaBancaria()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new ContaBancaria { Nome = "Banco do Brasil", Agencia = "520", Conta = "785-00" };            
            _context.ContasBancarias.Add(model);
            _context.SaveChanges();
            var contaBancaria = new ContaBancaria { Id = model.Id, Nome = model.Nome, Agencia = model.Agencia, Conta = model.Conta };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Nome = "Santander";
            model.Agencia = "521";
            model.Conta = "985-80";
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var contaBancariaEditada = _context.ContasBancarias.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(contaBancariaEditada, "conta bancária não foi criada corretamente");
            Assert.That(contaBancaria.Agencia, Is.Not.EqualTo(contaBancariaEditada.Agencia));
            Assert.That(contaBancaria.Conta, Is.Not.EqualTo(contaBancariaEditada.Conta));
            Assert.That(contaBancaria.Nome, Is.Not.EqualTo(contaBancariaEditada.Nome));
        }

        [Test]
        public void TestDeletarContaBancaria() => Assert.Pass();

        [Test]
        public void TestVisualizarContaBancaria() => Assert.Pass();

        [Test]
        public void TestEditarFormaPagamentoAssociadaAUmaDespesa() => Assert.Pass();

        [Test]
        public void TestDeletarFormaPagamentoAssociadaAUmaDespesa() => Assert.Pass();

        [TearDown]
        public void TearDown()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _context.Dispose();
            _controller.Dispose();
        }

    }
}