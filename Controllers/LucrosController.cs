using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Lucros")]
    public class LucrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LucrosController(DataContext context)
        {
            _context = context;
        }

        #region Get
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                List<Lucros> lista = await _context.
                TB_LUCROS.ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getId(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Lucros lucros = await _context.TB_LUCROS
                .FirstOrDefaultAsync(l => l.Id == id);

                if (lucros == null)
                    throw new Exception("ID não encontrado.");

                return Ok(lucros);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddLucros(Lucros lucros)
        {

            try
            {
                Produto produto = await _context.TB_PRODUTOS
             .FirstOrDefaultAsync(p => p.Id == lucros.Id_produto);

                lucros.Produto = produto;

                await _context.TB_LUCROS.AddAsync(lucros);
                await _context.SaveChangesAsync();

                string mensagem = $"Lucro adiciono ao Sistema com o Id: {lucros.Id}";

                return Ok(mensagem);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutLucros(Lucros l)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
             .FirstOrDefaultAsync(p => p.Id == l.Id_produto);

                l.Produto = produto;
                _context.TB_LUCROS.Update(l);

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

                Lucros lucros = await _context
                .TB_LUCROS.FirstOrDefaultAsync(l => l.Id == id);

                if (lucros == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_LUCROS.Remove(lucros);

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