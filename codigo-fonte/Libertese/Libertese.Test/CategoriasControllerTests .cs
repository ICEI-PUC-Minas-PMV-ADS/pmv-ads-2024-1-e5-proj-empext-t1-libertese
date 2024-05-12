using Libertese.Data;
using Libertese.Domain.Entities.Precificacao;
using Libertese.Web.Controllers.Precificacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Libertese.Domain.Enums;
using Libertese.Test.Context;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;


namespace Libertese.Test
{
    [TestFixture]
    public class CategoriasControllerTests

    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private CategoriasController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new CategoriasController(_context);
        }

        [Test]
        public async Task TestCriarCategoria()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var categoria = new Categoria { Nome = "Camisas" };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(categoria);
            var categoriaCriada = _context.Categorias.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(categoriaCriada, "categoria não foi criada no banco de dados");
            Assert.That(categoria.Nome, Is.EqualTo(categoriaCriada.Nome));
        }

        [Test]
        public async Task TesteEditarCategoria()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Categoria { Nome = "Calças" };
            _context.Categorias.Add(model);    
            _context.SaveChanges();
            var categoria = new Categoria { Id = model.Id, Nome = model.Nome };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Nome = "Moletons";
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var categoriaEditada = _context.Categorias.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(categoriaEditada, "categoria não foi criada corretamente");
            Assert.That(categoria.Nome, Is.Not.EqualTo(categoriaEditada.Nome));

        }

        [Test]
        public async Task TestDeletarCategoria()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Categoria { Nome = "Bermudas" };
            _context.Categorias.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.DeleteConfirmed(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var categoriaDeletada = _context.Categorias.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(categoriaDeletada, "categoria não foi deletada corretamente");
        }

        [Test]
        public async Task TestVisualizarCategoria()
        {
            //// estudando triple A
            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Categoria { Nome = "Camisas" };
            _context.Categorias.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            var view =  await _controller.Details(model.Id) as ViewResult;

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