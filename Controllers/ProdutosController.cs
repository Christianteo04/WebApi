using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.DTOs;
using WebApi.Interface;
using AutoMapper;
using WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class ProdutosController(IProduto iprodutos, IMapper mapper) : ControllerBase
    {
        private readonly IProduto _iprodutos = iprodutos;
        private readonly IMapper _mapper = mapper;

        [HttpPost("AddProduto")]
        public async Task<ActionResult> PostProduto([FromBody] ProdutosDTO produtosDTO)
        {
            if (produtosDTO is null)
                return BadRequest("Dados inválidos");

            var produtos = _mapper.Map<Produto>(produtosDTO);

            await _iprodutos.AddProdutos(produtos);

            return Ok(produtos);
        }

        [HttpGet("GetProdutos")]
        public async Task<ActionResult> GetProdutos()
        {
            List<Produto> produtos = await _iprodutos.GetProdutos();
            List<ProdutosDTO> listProdutosDTO = _mapper.Map<List<ProdutosDTO>>(produtos);

            return Ok(listProdutosDTO);
        }

        [HttpDelete("DeleteProduto")]
        public async Task<ActionResult> DeleteProduto(int idProduto)
        {
            await _iprodutos.DeleteProduto(idProduto);
            return Ok("Produto deletado com sucesso");
        }

        [HttpPut("UpdateProduto")]
        public async Task<ActionResult> PutProduto([FromBody] ProdutosDTO produtosDTO)
        {
            if (produtosDTO is null)
                return BadRequest("Dados inválidos");

            var produto = _mapper.Map<Produto>(produtosDTO);

            await _iprodutos.UpdateProduto(produto);

            return Ok("Produto atualizado com sucesso");
        }

        [HttpGet("GetProdutoPorNome")]
        public async Task<ActionResult> GetProdutoPorNome([FromBody] string nomeProduto)
        {
            List<Produto> produtos = await _iprodutos.GetProdutosPorNome(nomeProduto);
            List<ProdutosDTO> listProdutosDTO = _mapper.Map<List<ProdutosDTO>>(produtos);

            return Ok(listProdutosDTO);
        }

        [HttpGet("GetProdutoPorId/{idProduto}")]
        public async Task<ActionResult> GetProdutoPorId(int idProduto)
        {
            Produto produto = await _iprodutos.GetProdutoById(idProduto);
            ProdutosDTO produtosDTO = _mapper.Map<ProdutosDTO>(produto);

            return Ok(produtosDTO);
        }
    }
}
