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
    public class FormaPagamentosControllerTests
    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private FormaPagamentosController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new FormaPagamentosController(_context);
        }

        [Test]
        public async Task TestCriarFormaPagamento() 
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var formaPagamento =  new FormaPagamento { Descricao = "Depósito em Conta"};

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(formaPagamento);
            var formaPagamentoCriada = _context.FormaPagamentos.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(formaPagamentoCriada, "forma de pagamento não foi criada no banco de dados");    
            Assert.That(formaPagamento.Descricao, Is.EqualTo(formaPagamentoCriada.Descricao));
        }

        [Test]
        public async Task TesteEditarFormaPagamento()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new FormaPagamento { Descricao = "Depósito em Conta" };
            _context.FormaPagamentos.Add(model);
            _context.SaveChanges();
            var formaPagamento = new FormaPagamento { Id = model.Id, Descricao = model.Descricao };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Descricao = "Pix";
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var formaPagamentoEditada = _context.FormaPagamentos.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(formaPagamentoEditada, "forma pagamento não foi criada corretamente");
            Assert.That(formaPagamento.Descricao, Is.Not.EqualTo(formaPagamentoEditada.Descricao));

        }

        [Test]
        public async Task TestDeletarFormaPagamento()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new FormaPagamento { Descricao = "Pix" };
            _context.FormaPagamentos.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.DeleteConfirmed(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var classificacaoDeletada = _context.FormaPagamentos.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(classificacaoDeletada, "Forma de pagamento não foi deletada corretamente");
        }

        [Test]
        public async Task TestVisualizarFormaPagamento()
        {
            //// estudando triple A
            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new FormaPagamento { Descricao = "Cartão de crétido" };
            _context.FormaPagamentos.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            var view = await _controller.Details(model.Id) as ViewResult;

            /// A - Assert: onde verifica se a operação passou ou falhou.
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