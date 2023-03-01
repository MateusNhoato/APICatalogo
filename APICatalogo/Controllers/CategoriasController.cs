using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            try
            {
                var categorias = _context.Categorias;

                if (categorias is null)
                    return NotFound("Categorias não foram encontradas.");

                return categorias.Include(p => p.Produtos).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {        
            try
            {
                var categorias = _context.Categorias.AsNoTracking().ToList();

                if (categorias is null)
                    return NotFound("Categorias não foram encontradas.");

                return categorias;
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult<Categoria> Get(int id) 
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

                if (categoria is null)
                    return NotFound($"Categoria com id = {id} não encontrada");

                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            try
            {
                if (categoria is null)
                    return BadRequest();

                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria",
                                                new { id = categoria.Id },
                                                categoria);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.Id)
                    return BadRequest();

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(categoria);
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
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

                if (categoria is null)
                    return NotFound($"Categoria com id={id} não localizada");

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no pedido.");
            }
        }


    }
}
