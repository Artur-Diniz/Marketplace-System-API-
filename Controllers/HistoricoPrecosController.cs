using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("HistoricoPrecos")]
    public class HistoricoPrecosController : ControllerBase
    {
        private readonly DataContext _context;

        public HistoricoPrecosController(DataContext context)
        {
            _context = context;
        }

        #region Get
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Historico_precos> historico_Precos = await _context
                .TB_HISTORICO_PRECOS.ToListAsync();

                return Ok(historico_Precos);
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

                Historico_precos historico_Precos = await _context
                .TB_HISTORICO_PRECOS.FirstOrDefaultAsync(hp => hp.Id == id);

                if (historico_Precos == null)
                    throw new Exception("ID não encontrado.");
                return Ok(historico_Precos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> PostHistoricoPreco(Historico_precos hp)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
                   .FirstOrDefaultAsync(p => p.Id == hp.Id_produto);

                hp.Produto = produto;

                await _context.TB_HISTORICO_PRECOS.AddAsync(hp);
                await _context.SaveChangesAsync();

                string mensagem = $"Historico adiciona ao Sistema com o Id{hp.Id}";

                return Ok(mensagem);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutHistoricoPrecos(Historico_precos hp)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
                   .FirstOrDefaultAsync(p => p.Id == hp.Id_produto);

                hp.Produto = produto;

                _context.TB_HISTORICO_PRECOS.Update(hp);
                await _context.SaveChangesAsync();

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

                Historico_precos historico_Precos = await _context
                .TB_HISTORICO_PRECOS.FirstOrDefaultAsync(hp => hp.Id == id);

                if (historico_Precos == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_HISTORICO_PRECOS.Remove(historico_Precos);
               
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