using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entity
{
    public class Produto : Identity
    {
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
