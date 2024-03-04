using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Interface;
using WebApi.Entity;

namespace WebApi.Repository
{
    public class ProdutosRepository(AppDbContext context) : IProduto
    {
        protected readonly AppDbContext _context = context;

        public async Task AddProdutos(Produto produtos)
        {
            _context.Produto.Add(produtos);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetProdutos()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task DeleteProduto(int idProduto)
        {
           var produto =  await GetProdutoById(idProduto);

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduto(Produto produto)
        {
            ArgumentNullException.ThrowIfNull(produto);

            var existingProduto = await GetProdutoById(produto.Id);

            if(produto.Preco <= 0)
                throw new ArgumentException("Preço do produto não pode ser menor ou igual a zero.");

            _context.Entry(existingProduto).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> GetProdutoById(int idProduto)
        {
            var produto = await _context.Produto.FindAsync(idProduto);

            if (produto == null)
                throw new KeyNotFoundException($"Produto com ID {idProduto} não encontrado.");

            return produto;
        }

        public async Task<List<Produto>> GetProdutosPorNome(string nomeProduto)
        {
            var produtosEncontrados = await _context.Produto
                .Where(p => EF.Functions.Like(p.Nome, $"%{nomeProduto}%"))
                .ToListAsync();

            return produtosEncontrados;
        }
    }
}
