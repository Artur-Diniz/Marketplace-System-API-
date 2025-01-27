using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecoController(DataContext context)
        {
            _context = context;
        }


        #region get

        [HttpGet("getAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<Enderecos> enderecos = await _context.TB_ENDERECOS.ToListAsync();

                return Ok(enderecos);

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

                Enderecos enderecos = await _context
                .TB_ENDERECOS.FirstOrDefaultAsync(e => e.Id == id);

                if (enderecos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClienteCPF/{id}")]
        public async Task<IActionResult> GetIdClienteCPF(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Enderecos enderecos = await _context
                .TB_ENDERECOS.FirstOrDefaultAsync(e => e.Clientes_CPF_Id == id);

                if (enderecos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ClienteCnpj/{id}")]
        public async Task<IActionResult> GetIdClienteCnpj(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Enderecos enderecos = await _context
                .TB_ENDERECOS.FirstOrDefaultAsync(e => e.Clientes_Cnpj_Id == id);

                if (enderecos == null)
                    throw new Exception("ID não encontrado.");

                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUF/{UF}")]
        public async Task<IActionResult> GetUF(string UF)
        {
            try
            {
                List<Enderecos> enderecos = await _context.TB_ENDERECOS
                .Where(c => c.UF.ToLower().Contains(UF.ToLower()))
                .ToListAsync();

                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCidade/{cidade}")]
        public async Task<IActionResult> GetCidade(string cidade)
        {
            try
            {
                List<Enderecos> enderecos = await _context.TB_ENDERECOS
                .Where(c => c.Cidade.ToLower().Contains(cidade.ToLower()))
                .ToListAsync();

                return Ok(enderecos);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddEndercos(Enderecos enderecos)
        {
            try
            {
                if (enderecos.Clientes_CPF_Id == null || enderecos.Clientes_Cnpj_Id == null)
                    throw new Exception("O endereço deve estar vinculado a um cliente");


                if (enderecos.Clientes_Cnpj_Id != 0)
                {
                    Clientes_Cnpj clientes_Cnpj = await _context
                    .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == enderecos.Clientes_Cnpj_Id);

                    enderecos.Clientes_Cnpj = clientes_Cnpj;
                }
                else
                {
                    Clientes_CPF clientes_Cpf = await _context
                     .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == enderecos.Clientes_CPF_Id);

                    enderecos.Clientes_CPF = clientes_Cpf;
                }

                await _context.TB_ENDERECOS.AddAsync(enderecos);
                await _context.SaveChangesAsync();

                string mensagem = $"Endereço adiciono ao Sistema com o Id: {enderecos.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Enderecos enderecos)
        {
            try
            {
                if (enderecos.Clientes_CPF_Id == null || enderecos.Clientes_Cnpj_Id == null)
                    throw new Exception("O endereço deve estar vinculado a um cliente");

                Enderecos endeco = await _context
                    .TB_ENDERECOS.FirstOrDefaultAsync(e => e.Id == enderecos.Id);

                if (endeco.Clientes_Cnpj_Id != 0)
                    enderecos.Clientes_Cnpj_Id = endeco.Clientes_Cnpj_Id;
                if (endeco.Clientes_CPF_Id != 0)
                    enderecos.Clientes_CPF_Id = endeco.Clientes_CPF_Id;


                if (enderecos.Clientes_Cnpj_Id != 0)
                {
                    Clientes_Cnpj clientes_Cnpj = await _context
                    .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == enderecos.Clientes_Cnpj_Id);

                    enderecos.Clientes_Cnpj = clientes_Cnpj;
                }
                else
                {
                    Clientes_CPF clientes_Cpf = await _context
                     .TB_CLIENTES_CPF.FirstOrDefaultAsync(c => c.Id == enderecos.Clientes_CPF_Id);

                    enderecos.Clientes_CPF = clientes_Cpf;
                }

                _context.TB_ENDERECOS.Update(enderecos);

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

                Enderecos enderecos = await _context
                .TB_ENDERECOS.FirstOrDefaultAsync(e => e.Id == id);

                if (enderecos == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_ENDERECOS.Remove(enderecos);
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