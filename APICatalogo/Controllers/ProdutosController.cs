using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();

                if (produtos is null)
                    return NotFound("Produtos não encontrados");

                return produtos;
            }
            catch (Exception)
            {

                return StatusCode(500,"Ocorreu um erro no pedido.");
            }
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produtos = _context.Produtos;

                var produto = produtos.FirstOrDefault(p => p.Id == id);

                if (produto is null)
                    return NotFound($"Produto com id={id} não foi encontrado.");

                return produto;
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }     
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto is null)
                    return BadRequest();

                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterProduto",
                                                new { id = produto.Id },
                                                produto);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.Id)
                    return BadRequest("Id não corresponde a id do produto.");

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(produto);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

                if (produto is null)
                    return NotFound("Produto não localizado");

                _context.Produtos.Remove(produto);
                _context.SaveChanges();

                return Ok(produto);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }
    }
}
