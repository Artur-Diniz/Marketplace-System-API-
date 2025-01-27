using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Impostos")]
    public class ImpostosController : ControllerBase
    {
        private readonly DataContext _context;

        public ImpostosController(DataContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Impostos> impostos = await _context
                .TB_IMPOSTOS.ToListAsync();

                return Ok(impostos);
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

                Impostos impostos = await _context.TB_IMPOSTOS
                .FirstOrDefaultAsync(i => i.Id == id);

                if (impostos == null)
                    throw new Exception("ID não encontrado.");


                return Ok(impostos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Produto/{id}")]
        public async Task<IActionResult> getProduto(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Impostos impostos = await _context.TB_IMPOSTOS
                .FirstOrDefaultAsync(i => i.Id_produto == id);

                if (impostos == null)
                    throw new Exception("ID não encontrado.");


                return Ok(impostos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Data")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                List<Impostos> impostos = await _context
                .TB_IMPOSTOS.OrderBy(i => i.data_inicio).ToListAsync();

                return Ok(impostos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddImposto(Impostos im)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
              .FirstOrDefaultAsync(p => p.Id == im.Id_produto);

                im.Produto = produto;

                await _context.TB_IMPOSTOS.AddAsync(im);
                await _context.SaveChangesAsync();

                string mensagem = $"Imposto adiciono ao Sistema com o Id: {im.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        public async Task<IActionResult> PutImposto(Impostos im)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
             .FirstOrDefaultAsync(p => p.Id == im.Id_produto);

                im.Produto = produto;

                _context.TB_IMPOSTOS.Update(im);


                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImposto(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Impostos im = await _context.TB_IMPOSTOS.FirstOrDefaultAsync(i => i.Id == id);

                if (im == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_IMPOSTOS.Remove(im);
                await _context.SaveChangesAsync();

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