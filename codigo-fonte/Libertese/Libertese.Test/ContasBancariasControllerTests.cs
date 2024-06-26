using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Test.Context;
using Libertese.Web.Controllers.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

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

            /// A - Arrange: configura��es necess�rias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var contaBancaria =  new ContaBancaria { Nome = "Ita�", Agencia = "120", Conta = "800-10"};

            /// A - Act: chama-se o metodo ou fun��o para provar o teste.
            await _controller.Create(contaBancaria);
            var contaBancariaCriada = _context.ContasBancarias.FirstOrDefault();


            /// A - Assert: onde verifica se a opera��o passou ou falhou.
            Assert.IsNotNull(contaBancariaCriada, "conta banc�ria n�o foi criada no banco de dados");    
            Assert.That(contaBancaria.Agencia, Is.EqualTo(contaBancariaCriada.Agencia));
            Assert.That(contaBancaria.Conta, Is.EqualTo(contaBancariaCriada.Conta));

        }

        [Test]
        public async Task TestEditarContaBancaria()
        {
            //// estudando triple A

            /// A - Arrange: configura��es necess�rias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new ContaBancaria { Nome = "Banco do Brasil", Agencia = "520", Conta = "785-00" };            
            _context.ContasBancarias.Add(model);
            _context.SaveChanges();
            var contaBancaria = new ContaBancaria { Id = model.Id, Nome = model.Nome, Agencia = model.Agencia, Conta = model.Conta };

            /// A - Act: chama-se o metodo ou fun��o para provar o teste.
            model.Nome = "Santander";
            model.Agencia = "521";
            model.Conta = "985-80";
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a opera��o passou ou falhou.
            var contaBancariaEditada = _context.ContasBancarias.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(contaBancariaEditada, "conta banc�ria n�o foi criada corretamente");
            Assert.That(contaBancaria.Agencia, Is.Not.EqualTo(contaBancariaEditada.Agencia));
            Assert.That(contaBancaria.Conta, Is.Not.EqualTo(contaBancariaEditada.Conta));
            Assert.That(contaBancaria.Nome, Is.Not.EqualTo(contaBancariaEditada.Nome));
        }

        [Test]
        public async Task TestDeletarContaBancaria()
        {
            //// estudando triple A

            /// A - Arrange: configura��es necess�rias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new ContaBancaria { Nome = "NU  Pagamentos S/A", Agencia = "554", Conta = "785-12" };
            _context.ContasBancarias.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou fun��o para provar o teste.
            await _controller.DeleteConfirmed(model.Id);

            /// A - Assert: onde verifica se a opera��o passou ou falhou.
            var classificacaoDeletada = _context.ContasBancarias.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(classificacaoDeletada, "conta bancaria n�o foi deletada corretamente");
        }

        [Test]
        public async Task TestVisualizarClassificacao()
        {
            //// estudando triple A
            /// A - Arrange: configura��es necess�rias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new ContaBancaria { Nome = "Banco do Nordeste", Agencia = "513", Conta = "125-12" };
            _context.ContasBancarias.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou fun��o para provar o teste.
            var view = await _controller.Details(model.Id) as ViewResult;

            /// A - Assert: onde verifica se a opera��o passou ou falhou.
            Assert.That(model, Is.EqualTo(view?.Model));

        }


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