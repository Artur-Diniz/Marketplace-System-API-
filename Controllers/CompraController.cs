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

        [HttpGet("Fornecedor/{id}")]
        public async Task<IActionResult> GetFornecedor(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Compras compras = await _context.TB_COMPRAS
                .Include(f => f.Fornecedores)
                .FirstOrDefaultAsync(f => f.Id_fornecedor == id);

                if (compras == null)
                    throw new Exception("ID não encontrado.");

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Produto/{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Compras compras = await _context.TB_COMPRAS
                .Include(f => f.Produto)
                .FirstOrDefaultAsync(f => f.Id_produto == id);

                if (compras == null)
                    throw new Exception("ID não encontrado.");

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetQuantidade")]
        public async Task<IActionResult> GetByQuantideOrder()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.OrderBy(c => c.Qunatidade).ToListAsync();

                return Ok(compras);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPreco")]
        public async Task<IActionResult> GetByPreco()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.OrderBy(c => c.preco_total).ToListAsync();

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStatus/Andamento")]
        public async Task<IActionResult> GetByStatusAndamento()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.Where(c => c.Status == ComprasEnum.Em_Andamento).ToListAsync();

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStatus/Pagamento")]
        public async Task<IActionResult> GetByStatusPagamento()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.Where(c => c.Status == ComprasEnum.Pagamaneto_Pendente).ToListAsync();

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStatus/Cancelado")]
        public async Task<IActionResult> GetByStatusCancelado()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.Where(c => c.Status == ComprasEnum.Cancelado).ToListAsync();

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStatus/Finalizado")]
        public async Task<IActionResult> GetByStatusFinalizado()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.Where(c => c.Status == ComprasEnum.Finalizada).ToListAsync();

                return Ok(compras);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStatus/Solicitando")]
        public async Task<IActionResult> GetByStatusSolicitando()
        {
            try
            {
                List<Compras> compras = await _context
                 .TB_COMPRAS.Where(c => c.Status == ComprasEnum.Solicitando_Produtos).ToListAsync();

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

                Fornecedores fornecedor = await _context.TB_FORNECEDORES
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

                Fornecedores fornecedor = await _context.TB_FORNECEDORES
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