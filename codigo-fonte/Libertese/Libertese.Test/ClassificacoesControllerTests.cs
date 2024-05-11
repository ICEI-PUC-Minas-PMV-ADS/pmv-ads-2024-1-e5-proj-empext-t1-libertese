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
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
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
        public async Task TesteEditarClassificacao()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Classificacao { Tipo = (int)ClassificacaoTipo.Despesas, Descricao = "Impostos" };
            _context.Classificacoes.Add(model);    
            _context.SaveChanges();
            var classificacao = new Classificacao { Id = model.Id, Descricao = model.Descricao };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Descricao = "Salarios";
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var classificacaoEditada = _context.Classificacoes.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(classificacaoEditada, "classificação não foi criada corretamente");
            Assert.That(classificacao.Descricao, Is.Not.EqualTo(classificacaoEditada.Descricao));

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
            await _controller.Delete(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var classificacaoDeletada = _context.Classificacoes.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(classificacaoDeletada, "classificação não foi deletada corretamente");
        }

        [Test]
        public async Task TestVisualizarClassificacao()
        {
            //// estudando triple A
            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Classificacao { Tipo = (int)ClassificacaoTipo.Receitas, Descricao = "Venda" };
            _context.Classificacoes.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            var view =  await _controller.Details(model.Id) as ViewResult;

            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.That(model, Is.EqualTo(view?.Model));

        }

        [Test]
        public void TestEditarClassificacaoAssociadaAUmaDespesa()
        {

        }

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