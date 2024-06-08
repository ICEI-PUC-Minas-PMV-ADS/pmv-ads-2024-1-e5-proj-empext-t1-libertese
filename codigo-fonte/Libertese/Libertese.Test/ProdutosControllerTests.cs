using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Libertese.Domain.Enums;
using Libertese.Test.Context;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using Libertese.ViewModels;
using Microsoft.AspNetCore.Mvc;


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
            // Arrange: configurações necessárias para o teste rodar.
            var now = DateTime.Now;
            var produto = new ProdutoCreateViewModel
            {
                Nome = "Bolsa",
                TempoProducao = 2,
                Margem = 2,
                CategoriaId = 2,
                DataAtualizacao = now,
                DataCriacao = now,
                MateriaisJson = "[]" 
            };

            // Act: chama-se o método ou função para provar o teste.
            var result = await _controller.Create(produto);

            // Verifica se houve erro de ModelState e loga os erros
            if (result is ViewResult viewResult && !viewResult.ViewData.ModelState.IsValid)
            {
                var errors = viewResult.ViewData.ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    TestContext.WriteLine($"ModelState error: {error.ErrorMessage}");
                }
            }

            // Assert: verifica se a operação passou ou falhou.
            Assert.IsInstanceOf<RedirectToActionResult>(result, "A criação do produto não redirecionou corretamente.");

            // Verifica se o produto foi realmente criado no banco de dados.
            var produtoCriado = _context.Produtos.FirstOrDefault(p => p.Nome == "Bolsa");
            Assert.IsNotNull(produtoCriado, "Produto não foi criado no banco de dados.");
            Assert.That(produto.Nome, Is.EqualTo(produtoCriado.Nome));
            Assert.That(produto.TempoProducao, Is.EqualTo(produtoCriado.TempoProducao));
            Assert.That(produto.Margem, Is.EqualTo(produtoCriado.Margem));
            Assert.That(produto.CategoriaId, Is.EqualTo(produtoCriado.CategoriaId));

            // Verificação de datas com intervalo aceitável
            Assert.That(produto.DataAtualizacao, Is.EqualTo(produtoCriado.DataAtualizacao).Within(TimeSpan.FromSeconds(1)));
            Assert.That(produto.DataCriacao, Is.EqualTo(produtoCriado.DataCriacao).Within(TimeSpan.FromSeconds(1)));
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