using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("ClienteCpf")]
    public class Cliente_CpfController : ControllerBase
    {
        private readonly DataContext _context;

        public Cliente_CpfController(DataContext context)
        {
            _context = context;
        }

        #region  get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Clientes_CPF> clientes_CPF = await _context
              .TB_CLIENTES_CPF.ToListAsync();

                return Ok(clientes_CPF);

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

                Clientes_CPF clientes = await _context
                .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == id);


                if (clientes == null)
                    throw new Exception("ID não encontrado.");

                return Ok(clientes);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("CPF/{cpf}")]
        public async Task<IActionResult> getCPF(string cpf)
        {
            try
            {
                if (cpf == "")
                    throw new Exception("O cnpj não pode ser igual Zero.");

                Clientes_CPF clientes = await _context
                .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.CPF == cpf);


                if (clientes == null)
                    throw new Exception("cnpj não encontrado.");

                return Ok(clientes);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddCliente(Clientes_CPF clientes)
        {
            try
            {
                await _context.TB_CLIENTES_CPF.AddAsync(clientes);
                await _context.SaveChangesAsync();

                string mensagem = $"Bem-Vindo  {clientes.Nome}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(Clientes_CPF clientes)
        {
            try
            {
                _context.TB_CLIENTES_CPF.Update(clientes);



                Clientes_CPF clientes_Cpf = await _context
                .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == clientes.Id);

                clientes.CPF = clientes_Cpf.CPF;

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

                Clientes_CPF clientes = await _context
                .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == id);


                if (clientes == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_CLIENTES_CPF.Remove(clientes);

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