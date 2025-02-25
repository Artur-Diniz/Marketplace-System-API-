using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("ClienteCnpj")]
    public class Cliente_CnpjController : ControllerBase
    {
        private readonly DataContext _context;

        public Cliente_CnpjController(DataContext context)
        {
            _context = context;
        }

        #region get

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Clientes_Cnpj> clientes_Cnpjs = await _context
                .TB_CLIENTES_CNPJ.ToListAsync();

                return Ok(clientes_Cnpjs);

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

                Clientes_Cnpj clientes = await _context
                .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == id);


                if (clientes == null)
                    throw new Exception("ID não encontrado.");

                return Ok(clientes);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("Cnpj/{cnpj}")]
        public async Task<IActionResult> getCNPJ(string cnpj)
        {
            try
            {
                if (cnpj == "")
                    throw new Exception("O cnpj não pode ser igual Zero.");

                Clientes_Cnpj clientes = await _context
                .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Cnpj == cnpj);


                if (clientes == null)
                    throw new Exception("cnpj não encontrado.");

                return Ok(clientes);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetByNome/{nome}")]
        public async Task<IActionResult> GetByNomeAproximado(string nome)
        {
            try
            {
                List<Clientes_Cnpj> lista = await _context.TB_CLIENTES_CNPJ
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

                if (lista == null)
                {
                    throw new Exception("Categoria não encontrada");
                }

                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll/Ativos")]
        public async Task<IActionResult> GetByStatus()
        {
            try
            {
                List<Clientes_Cnpj> lista = await _context.TB_CLIENTES_CNPJ
                .Where(c => c.Status == ClientesEnum.Ativo)
                .ToListAsync();

                if (lista == null)
                {
                    throw new Exception("Categoria não encontrada");
                }

                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> AddCliente(Clientes_Cnpj clientes)
        {
            try
            {
                Clientes_Cnpj cl = await _context
                .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Cnpj == clientes.Cnpj);

                if (cl != null)
                    throw new Exception("cnpj ja registrado no sistema.");

                await _context.TB_CLIENTES_CNPJ.AddAsync(clientes);
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
        public async Task<IActionResult> PutCliente(Clientes_Cnpj clientes)
        {
            try
            {
                _context.TB_CLIENTES_CNPJ.Update(clientes);



                Clientes_Cnpj clientes_Cnpj = await _context
                .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == clientes.Id);

                clientes.Cnpj = clientes_Cnpj.Cnpj;

                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Clientes_Cnpj clientes = await _context
                .TB_CLIENTES_CNPJ.FirstOrDefaultAsync(c => c.Id == id);


                if (clientes == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_CLIENTES_CNPJ.Remove(clientes);

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