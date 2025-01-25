using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("ItensPedidos")]
    public class ItensPedidosController : ControllerBase
    {
        private readonly DataContext _context;

        public ItensPedidosController(DataContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Itens_Pedidos> itens_Pedidos = await _context
                .TB_ITENS_PEDIDOS.ToListAsync();

                return Ok(itens_Pedidos);
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

                Itens_Pedidos itens_Pedido = await _context
                .TB_ITENS_PEDIDOS.FirstOrDefaultAsync(ip => ip.Id == id);

                if (itens_Pedido == null)
                    throw new Exception("ID não encontrado.");

                return Ok(itens_Pedido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> PostItens(Itens_Pedidos itens_Pedidos)
        {

            try
            {
                Produto produto = await _context.TB_PRODUTOS
                .FirstOrDefaultAsync(p => p.Id == itens_Pedidos.Id_produto);

                Pedidos pedidos = await _context.TB_PEDIDOS
                .FirstOrDefaultAsync(p => p.Id == itens_Pedidos.Id_pedido);

                itens_Pedidos.Produto = produto;
                itens_Pedidos.Pedidos = pedidos;

                await _context.TB_ITENS_PEDIDOS.AddAsync(itens_Pedidos);
                await _context.SaveChangesAsync();

                string mensagem = $"Itens adiciono ao pedido foi incluido no sistema com o Id: {itens_Pedidos.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutItensPedidos(Itens_Pedidos itens_Pedidos)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
               .FirstOrDefaultAsync(p => p.Id == itens_Pedidos.Id_produto);

                Pedidos pedidos = await _context.TB_PEDIDOS
                .FirstOrDefaultAsync(p => p.Id == itens_Pedidos.Id_pedido);

                itens_Pedidos.Produto = produto;
                itens_Pedidos.Pedidos = pedidos;

                _context.TB_ITENS_PEDIDOS.Update(itens_Pedidos);

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

                Itens_Pedidos itens_Pedidos = await _context.TB_ITENS_PEDIDOS
                .FirstOrDefaultAsync(ip => ip.Id == id);

                if (itens_Pedidos == null)
                    throw new Exception("ID não encontrado.");


                _context.TB_ITENS_PEDIDOS.Remove(itens_Pedidos);
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