using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly DataContext _context;

        public FornecedorController(DataContext context)
        {
            _context = context;
        }

        #region  Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {

                List<Fornecedores> fornecedores = await _context
                .TB_FORNECEDORES.ToListAsync();

                return Ok(fornecedores);
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


                Fornecedores fornecedor = await _context
                .TB_FORNECEDORES.FirstOrDefaultAsync(f => f.Id == id);

                if (fornecedor == null)
                    throw new Exception("ID não encontrado.");

                return Ok(fornecedor);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Nome/{nome}")]
        public async Task<IActionResult> GetNome(string nome)
        {
            try
            {
                List<Fornecedores> lista = await _context.TB_FORNECEDORES
                .Where(c => c.Nome.ToLower().Contains(nome.ToLower()))
                .ToListAsync();

                if (lista == null)
                {
                    throw new Exception("Fornecedor não encontrado");
                }

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FornecedorAtivo")]
        public async Task<IActionResult> GetAtivo()
        {
            try
            {
                List<Fornecedores> lista = await _context.TB_FORNECEDORES
                    .Where(c => c.Fornecedor_Ativo==true)
                    .ToListAsync();

                if (lista == null)
                {
                    throw new Exception("Fornecedor não encontrado");
                }

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion


        [HttpPost]
        public async Task<IActionResult> Post(Fornecedores fornecedor)
        {
            try
            {
                await _context.TB_FORNECEDORES.AddAsync(fornecedor);

                await _context.SaveChangesAsync();

                string mensagem = $"Fornecedor adiconado ao sistema com o Id: {fornecedor.Id}";

                return Ok(mensagem);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutFornecedor(Fornecedores fornecedor)
        {

            try
            {
                _context.TB_FORNECEDORES.Update(fornecedor);

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

                Fornecedores fornecedor = await _context.TB_FORNECEDORES.FirstOrDefaultAsync(f => f.Id == id);

                if (fornecedor == null)
                    throw new Exception("ID não encontrado.");


                _context.TB_FORNECEDORES.Remove(fornecedor);

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