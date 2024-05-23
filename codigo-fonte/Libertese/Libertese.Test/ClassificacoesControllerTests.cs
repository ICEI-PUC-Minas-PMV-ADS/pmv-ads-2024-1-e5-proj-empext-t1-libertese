using Libertese.Data;
using Libertese.Domain.Entities.Financeiro;
using Libertese.Web.Controllers.Financeiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Libertese.Domain.Enums;
using Libertese.Test.Context;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

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
        public async Task TestDeletarClassificacao()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Classificacao { Tipo = (int)ClassificacaoTipo.Despesas, Descricao = "Plano de Saúde" };
            _context.Classificacoes.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.DeleteConfirmed(model.Id, model.Tipo);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var classificacaoDeletada = _context.Classificacoes.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(classificacaoDeletada, "classificação não foi deletada corretamente");
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