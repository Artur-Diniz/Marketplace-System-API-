using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Comrpas")]
    public class ComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }

        #region  Get


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Compras> compras = await _context
                .TB_COMPRAS.ToListAsync();

                return Ok(compras);

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

                Compras compras = await _context
                .TB_COMPRAS.FirstOrDefaultAsync(c => c.Id == id);

                if (compras == null)
                    throw new Exception("ID não encontrado.");


                return Ok(compras);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        #endregion


        [HttpPost]
        public async Task<IActionResult> AddCompras(Compras compras)
        {

            try
            {
                Produto produto = await _context.TB_PRODUTOS
                    .FirstOrDefaultAsync(p => p.Id == compras.Id_produto);

                Fornecedores fornecedor = await _context.TB_FORNEDORES
                .FirstOrDefaultAsync(p => p.Id == compras.Id_fornecedor);

                compras.Produto = produto;
                compras.Fornecedores = fornecedor;

                await _context.TB_COMPRAS.AddAsync(compras);
                await _context.SaveChangesAsync();

                string mensagem = $"Compra adiciono ao Sistema com o Id: {compras.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutCompras(Compras compras)
        {

            try
            {
                Produto produto = await _context.TB_PRODUTOS
                    .FirstOrDefaultAsync(p => p.Id == compras.Id_produto);

                Fornecedores fornecedor = await _context.TB_FORNEDORES
                .FirstOrDefaultAsync(p => p.Id == compras.Id_fornecedor);

                compras.Produto = produto;
                compras.Fornecedores = fornecedor;

                _context.TB_COMPRAS.Update(compras);

                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Compras compras = await _context.TB_COMPRAS.FirstOrDefaultAsync(c => c.Id == id);

                if (compras == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_COMPRAS.Remove(compras);

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