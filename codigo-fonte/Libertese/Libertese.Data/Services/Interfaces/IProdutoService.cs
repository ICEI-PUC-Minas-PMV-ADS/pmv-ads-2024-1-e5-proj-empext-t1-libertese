using Libertese.Domain.Entities.Precificacao;

namespace Libertese.Data.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<OperationResult> CriarProduto(Produto produto);
        Task<OperationResult> AtualizarProduto(Produto produto);
        Task<OperationResult> DeletarProduto(int id);
        Task<OperationResult> BuscarProduto(int id);
        Task<OperationResult> CriarCategoria(Categoria categoria);
        Task<OperationResult> AtualizarCategoria(Categoria categoria);
        Task<OperationResult> DeletarCategoria(int id);
        Task<OperationResult> BuscarCategoria(int id);
        Task<OperationResult> CriarMaterial(Material material);
        Task<OperationResult> AtualizarMaterial(Material material);
        Task<OperationResult> DeletarMaterial(int id);
        Task<OperationResult> BuscarMaterial(int id);
    }
}