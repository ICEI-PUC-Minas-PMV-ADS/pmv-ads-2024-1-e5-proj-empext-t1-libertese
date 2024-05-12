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
    public class MateriaisControllerTests

    {
        private ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private MateriaisController _controller;

        [SetUp]
        public void Setup()
        {
            _context = new ContextFactory();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            _transaction = _context.Database.BeginTransaction();
            _controller = new MateriaisController(_context);
        }

        [Test]
        public async Task TestCriarMaterial()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var material = new Material { Nome = "Botão", Preco = 2 };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.Create(material);
            var materialCriado = _context.Materiais.FirstOrDefault();


            /// A - Assert: onde verifica se a operação passou ou falhou.
            Assert.IsNotNull(materialCriado, "material criado no banco de dados");
            Assert.That(material.Nome, Is.EqualTo(materialCriado.Nome));
            Assert.That(material.Preco, Is.EqualTo(materialCriado.Preco));
        }

        [Test]
        public async Task TesteEditarMaterial()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Material { Nome = "Agulha", Preco = 1 };
            _context.Materiais.Add(model);    
            _context.SaveChanges();
            var material = new Material { Id = model.Id, Nome = model.Nome, Preco = model.Preco };

            /// A - Act: chama-se o metodo ou função para provar o teste.
            model.Nome = "Ziper";
            model.Preco = 2;
            await _controller.Edit(model.Id, model);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var materialEditado = _context.Materiais.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNotNull(materialEditado, "material não foi criada corretamente");
            Assert.That(material.Nome, Is.Not.EqualTo(materialEditado.Nome));
            Assert.That(material.Preco, Is.Not.EqualTo(materialEditado.Preco));

        }

        [Test]
        public async Task TestDeletarMaterial()
        {
            //// estudando triple A

            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Material { Nome = "Tecido", Preco = 77 };
            _context.Materiais.Add(model);
            _context.SaveChanges();

            /// A - Act: chama-se o metodo ou função para provar o teste.
            await _controller.DeleteConfirmed(model.Id);

            /// A - Assert: onde verifica se a operação passou ou falhou.
            var materialDeletado = _context.Materiais.Where(c => c.Id == model.Id).FirstOrDefault();
            Assert.IsNull(materialDeletado, "material não foi deletado corretamente");
        }

        [Test]
        public async Task TestVisualizarMaterial()
        {
            //// estudando triple A
            /// A - Arrange: configurações necessárias para o teste rodar.
            /// Inicializar variaveis , criar mocks ou spies.
            var model = new Material { Nome = "Tecido Malha", Preco = 80 };
            _context.Materiais.Add(model);
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