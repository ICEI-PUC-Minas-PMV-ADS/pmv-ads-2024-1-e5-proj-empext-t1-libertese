using Libertese.Data.Repositories.Interfaces;
using Libertese.Data.Services.Interfaces;
using Libertese.Domain.Entities.Precificacao;

namespace Libertese.Data.Services
{
    public class ProdutoService : IProdutoService
    { 
        private readonly IProdutoRepository<Produto> _produtoRepository;
        private readonly IMaterialRepository<Material> _materialRepository;
        private readonly ICategoriaRepository<Categoria> _categoriaRepository;

        public ProdutoService(
            IProdutoRepository<Produto> produtoRepository,
            IMaterialRepository<Material> materialRepository,
            ICategoriaRepository<Categoria> categoriaRepository
            )
        {
            _produtoRepository = produtoRepository;
            _materialRepository = materialRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<OperationResult> AtualizarCategoria(int id, Categoria categoria)
        {
            try
            {
                Categoria model = await _categoriaRepository.GetById(id);
                model.Nome = categoria.Nome;
                Categoria data = await _categoriaRepository.Update(model);
                return new OperationResult
                {
                    Data = data,
                    Message = "Categoria atualizada com sucesso!",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public async Task<OperationResult> AtualizarMaterial(int id, Material material)
        {
            try
            {
                Material data = await _materialRepository.Update(material);
                return new OperationResult
                {
                    Data = data,
                    Message = "Material atualizada com sucesso!",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public async Task<OperationResult> AtualizarProduto(int id, Produto produto)
        {
            try
            {
                Produto data = await _produtoRepository.Update(produto);
                return new OperationResult
                {
                    Data = data,
                    Message = "Produto atualizado com sucesso!",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public async Task<OperationResult> BuscarCategoria()
        {
            try
            {
                List<Categoria> data = await _categoriaRepository.GetAll();
                return new OperationResult
                {
                    Data = data,
                    Message = "",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public async Task<OperationResult> BuscarCategoria(int id)
        {
            try
            {
                Categoria data = await _categoriaRepository.GetById(id);
                return new OperationResult
                {
                    Data = data,
                    Message = "",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public Task<OperationResult> BuscarMaterial()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> BuscarMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> BuscarProduto()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> BuscarProduto(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> CriarCategoria(Categoria categoria)
        {
            try
            {
                Categoria data = await _categoriaRepository.Create(categoria);
                return new OperationResult
                {
                    Data = data,
                    Message = "Categoria inserida com sucesso!",
                    Error = false
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Data = null,
                    Message = ex.Message,
                    Error = true
                };
            }
        }

        public Task<OperationResult> CriarMaterial(Material material)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> CriarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeletarCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeletarMaterial(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> DeletarProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
