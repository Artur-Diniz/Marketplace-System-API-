using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidosController(DataContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.ToListAsync();

                return Ok(pedidos);

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

                Pedidos pedidos = await _context
                .TB_PEDIDOS.FirstOrDefaultAsync(p => p.Id == id);

                if (pedidos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(pedidos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DataPedidoRecente")]
        public async Task<IActionResult> getDataPedidoRecente()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.OrderBy(p => p.Data_Pedido).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DataPedidoAntiga")]
        public async Task<IActionResult> getDataPedidoAntiga()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.OrderByDescending(p => p.Data_Pedido).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DataEntregaRecente")]
        public async Task<IActionResult> getDataEntregaRecente()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.OrderBy(p => p.Data_Entrega).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("DataEntregaAntiga")]
        public async Task<IActionResult> getDataEntregaAntiga()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.OrderByDescending(p => p.Data_Entrega).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("EntragaPendente")]
        public async Task<IActionResult> getEntragaPendente()
        {
            try
            {

                List<Pedidos> pedidos = await _context
                .TB_PEDIDOS.Where(p => p.Data_Entrega == null).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClienteCpf/{cpf}")]
        public async Task<IActionResult> Getcpf(int cpf)
        {
            try
            {
                if (cpf == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Pedidos pedidos = await _context
                .TB_PEDIDOS.FirstOrDefaultAsync(p => p.Id_Cliente_CPF == cpf);

                if (pedidos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClienteCNPJ/{CNPJ}")]
        public async Task<IActionResult> GetCNPJ(int CNPJ)
        {
            try
            {
                if (CNPJ == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Pedidos pedidos = await _context
                .TB_PEDIDOS.FirstOrDefaultAsync(p => p.Id_Cliente_CNPJ == CNPJ);

                if (pedidos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("MaiorValor")]
        public async Task<IActionResult> GetMaiorvalor()
        {
            try
            {
                List<Pedidos> pedidos = await _context
                               .TB_PEDIDOS.OrderBy(p => p.Valor_pedido).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("MenorValor")]
        public async Task<IActionResult> GetMenorvalor()
        {
            try
            {
                List<Pedidos> pedidos = await _context
                               .TB_PEDIDOS.OrderByDescending(p => p.Valor_pedido).ToListAsync();

                return Ok(pedidos);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


        [HttpPost]
        public async Task<IActionResult> Addpedidos(Pedidos pedidos)
        {
            try
            {
                if (pedidos.Id_Cliente_CPF == null || pedidos.Id_Cliente_CNPJ == null)
                    throw new Exception("O endereço deve estar vinculado a um cliente");


                if (pedidos.Id_Cliente_CNPJ != 0)
                {
                    Clientes_Cnpj clientes_Cnpj = await _context
                                     .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == pedidos.Id_Cliente_CNPJ);

                    pedidos.Clientes_CNPJ = clientes_Cnpj;
                }
                else
                {
                    Clientes_CPF clientes_CPF = await _context
                                     .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == pedidos.Id_Cliente_CPF);

                    pedidos.Clientes_CPF = clientes_CPF;
                }

                await _context.TB_PEDIDOS.AddAsync(pedidos);
                await _context.SaveChangesAsync();

                string mensagem = $"Pedido adiciono ao Sistema com o Id: {pedidos.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(Pedidos pedidos)
        {
            try
            {
                if (pedidos.Id_Cliente_CPF == null || pedidos.Id_Cliente_CNPJ == null)
                    throw new Exception("O endereço deve estar vinculado a um cliente");

                Pedidos ped = await _context
                .TB_PEDIDOS.FirstOrDefaultAsync(p => p.Id == pedidos.Id);

                if (ped.Id_Cliente_CNPJ != 0)
                    pedidos.Id_Cliente_CNPJ = ped.Id_Cliente_CNPJ;
                if (ped.Id_Cliente_CPF != 0)
                    pedidos.Id_Cliente_CPF = ped.Id_Cliente_CPF;


                if (pedidos.Id_Cliente_CNPJ != 0)
                {
                    Clientes_Cnpj clientes_Cnpj = await _context
                                     .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == pedidos.Id_Cliente_CNPJ);

                    pedidos.Clientes_CNPJ = clientes_Cnpj;
                }
                else
                {
                    Clientes_CPF clientes_CPF = await _context
                                     .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == pedidos.Id_Cliente_CPF);

                    pedidos.Clientes_CPF = clientes_CPF;
                }

                _context.TB_PEDIDOS.Update(pedidos);

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

                Pedidos pedidos = await _context
                .TB_PEDIDOS.FirstOrDefaultAsync(p => p.Id == id);

                if (pedidos == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_PEDIDOS.Remove(pedidos);

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