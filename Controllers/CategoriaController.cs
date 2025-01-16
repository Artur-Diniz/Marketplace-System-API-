using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Categoria")]

    public class CategoriaController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriaController(DataContext context)
        {
            _context = context;
        }

        #region  Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Categoria> lista = await _context.TB_CATEGORIAS.ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetId(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    throw new Exception("O ID não pode ser igual Zero.");
                }

                Categoria categoria = await _context.TB_CATEGORIAS.FirstOrDefaultAsync(c => c.Id == Id);


                if (categoria == null)
                {
                    throw new Exception("ID não encontrado.");
                }

                return Ok(categoria);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Add(Categoria categoria)
        {
            try
            {

                await _context.TB_CATEGORIAS.AddAsync(categoria);
                await _context.SaveChangesAsync();

                string mensagem = $"A Categoria adiciona ao Sistema com o Id{categoria.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Categoria cat)
        {
            try
            {

                _context.TB_CATEGORIAS.Update(cat);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    throw new Exception("O ID não pode ser igual Zero.");
                }

                Categoria cat = await _context.TB_CATEGORIAS.FirstOrDefaultAsync(c => c.Id == Id);

                if (cat == null)
                {
                    throw new Exception("O ID não encontrado.");
                }

                _context.TB_CATEGORIAS.Remove(cat);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}