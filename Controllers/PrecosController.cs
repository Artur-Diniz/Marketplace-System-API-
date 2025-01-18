using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Precos")]
    public class PrecosController : ControllerBase
    {
        private readonly DataContext _context;

        public PrecosController(DataContext context)
        {
            _context = context;
        }

        #region  Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Precos> lista = await _context.TB_PRECOS
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");


                Precos precos = await _context.TB_PRECOS
                .Include(p => p.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);

                if (precos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(precos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddPrecos(Precos precos)
        {
            try
            {
                await _context.TB_PRECOS.AddAsync(precos);
                await _context.SaveChangesAsync();

                string mensagem = $"Precos adiciona ao Sistema com o Id{precos.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutPrecos(Precos p)
        {
            try
            {
                _context.TB_PRECOS.Update(p);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Precos precos = await _context.TB_PRECOS
                .FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_PRECOS.Remove(precos);
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