using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Web.Controllers.Financeiro;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data.Entity;

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
        public void TestEditarFormaPagamento() => Assert.Pass();

        [Test]
        public void TestDeletarFormaPagamento() => Assert.Pass();

        [Test]
        public void TestVisualizarFormaPagamento() => Assert.Pass();

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