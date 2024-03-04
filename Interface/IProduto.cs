using WebApi.Entity;

namespace WebApi.Interface
{
    public interface IProduto
    {
        Task AddProdutos(Produto produtos);
        Task<List<Produto>> GetProdutos();
        Task DeleteProduto(int idProduto);
        Task UpdateProduto (Produto produto);
        Task<List<Produto>> GetProdutosPorNome(string nomeProduto);
        Task<Produto> GetProdutoById(int idProduto);
    }
}
