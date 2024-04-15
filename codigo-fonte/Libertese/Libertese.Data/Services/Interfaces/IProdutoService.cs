using Libertese.Domain.Entities.Precificacao;

namespace Libertese.Data.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<OperationResult> CriarProduto(Produto produto);
        Task<OperationResult> AtualizarProduto(int id, Produto produto);
        Task<OperationResult> DeletarProduto(int id);
        Task<OperationResult> BuscarProduto();
        Task<OperationResult> BuscarProduto(int id);
        Task<OperationResult> CriarCategoria(Categoria categoria);
        Task<OperationResult> AtualizarCategoria(int id, Categoria categoria);
        Task<OperationResult> DeletarCategoria(int id);
        Task<OperationResult> BuscarCategoria();

        Task<OperationResult> BuscarCategoria(int id);
        Task<OperationResult> CriarMaterial(Material material);
        Task<OperationResult> AtualizarMaterial(int id, Material material);
        Task<OperationResult> DeletarMaterial(int id);
        Task<OperationResult> BuscarMaterial();
        Task<OperationResult> BuscarMaterial(int id);
    }
}