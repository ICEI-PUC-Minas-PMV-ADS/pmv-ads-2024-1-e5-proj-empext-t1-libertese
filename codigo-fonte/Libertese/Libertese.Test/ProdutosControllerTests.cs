using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Libertese.Domain.Enums;
using Libertese.Test.Context;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using Libertese.ViewModels;


namespace Libertese.Test
{
    [TestFixture]
    public class ProdutosControllerTests

    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private ProdutosController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new ProdutosController(_context);
        }

       
        [Test]
        public async Task TestCriarProduto()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var produto = new ProdutoCreateViewModel { Nome = "Bolsa", TempoProducao = 5, CategoriaId = 4 };
            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(produto);
            var produtoCriado = _context.Produtos.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(produtoCriado, "produto criado no banco de dados");
            Assert.That(produto.Nome, Is.EqualTo(produtoCriado.Nome));
            Assert.That(produto.TempoProducao, Is.EqualTo(produtoCriado.TempoProducao));
            Assert.That(produto.CategoriaId, Is.EqualTo(produtoCriado.CategoriaId));
           



        }

        [Test]
        public async Task TesteEditarProduto()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Produto { Nome = "Camisa Azul" };
            _context.Produtos.Add(model);
            _context.SaveChanges();
            var produtos = new Produto { Id = model.Id, Nome = model.Nome };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Nome = "Camisa Verde";
            await _controller.Edit(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var produtoEditado = _context.Produtos.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(produtoEditado, "produto não foi criado corretamente");
            Assert.That(produtos.Nome, Is.Not.EqualTo(produtoEditado.Nome));

        }

        [Test]
        public async Task TestDeletarProduto()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Produto { Nome = "Calça Jeans" };
            _context.Produtos.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.DeleteConfirmed(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var produtoDeletado = _context.Produtos.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(produtoDeletado, "produto não foi deletado corretamente");
        }

        [Test]
        public async Task TestVisualizarProduto()
        {
            //// estudando triple A
            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Produto { Nome = "Short Amarelo" };
            _context.Produtos.Add(model);
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