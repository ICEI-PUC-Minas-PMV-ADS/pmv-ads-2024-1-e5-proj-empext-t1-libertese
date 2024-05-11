using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Web.Controllers.Financeiro;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data.Entity;
using Libertese.Domain.Enums;
using Libertese.Test.Context;

namespace Libertese.Test
{
    [TestFixture]
    public class ClassificacoesControllerTests
    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private ClassificacoesController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new ClassificacoesController(_context);
        }

        [Test]
        public async Task TestCriarClassificacao()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var classificacao = new Classificacao { Tipo = (int)ClassificacaoTipo.Despesas, Descricao = "Impostos" };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(classificacao);
            var classificaoCriada = _context.Classificacoes.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(classificaoCriada, "classificação não foi criada no banco de dados");
            Assert.That(classificacao.Descricao, Is.EqualTo(classificaoCriada.Descricao));
        }

        [Test]
        public void TestEditarClassificacao() => Assert.Pass();

        [Test]
        public void TestDeletarClassificacao() => Assert.Pass();

        [Test]
        public void TestVisualizarClassificacao() => Assert.Pass();

        [Test]
        public void TestEditarClassificacaoAssociadaAUmaDespesa() => Assert.Pass();

        [Test]
        public void TestEditarClassificacaoAssociadaAUmaReceita() => Assert.Pass();

        [Test]
        public void TestDeletarClassificacaoAssociadaAUmaDespesa() => Assert.Pass();

        [Test]
        public void TestDeletarClassificacaoAssociadaAUmaReceita() => Assert.Pass();

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