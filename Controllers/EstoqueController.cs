using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Estoque")]
    public class EstoqueController : ControllerBase
    {
        private readonly DataContext _context;

        public EstoqueController(DataContext context)
        {
            _context = context;
        }

        #region  Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<Estoque> lista = await _context.TB_ESTOQUE
                .ToListAsync();

                return Ok(lista);
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


                Estoque estoque = await _context.TB_ESTOQUE
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(e => e.Id == id);

                if (estoque == null)
                    throw new Exception("ID não encontrado.");


                return Ok(estoque);
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


                Estoque estoque = await _context.TB_ESTOQUE
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(e => e.Id_Produto == id);

                if (estoque == null)
                    throw new Exception("ID não encontrado.");


                return Ok(estoque);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetQuantidade")]
        public async Task<IActionResult> getQuantidade()
        {
            try
            {
                List<Estoque> lista = await _context.TB_ESTOQUE
                .OrderBy(e => e.Quantidade)
                .ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetQuantidadeDisponivel")]
        public async Task<IActionResult> getQuantidadedisponivel()
        {
            try
            {
                List<Estoque> lista = await _context.TB_ESTOQUE
                .OrderBy(e => e.Quantidade_disponivel)
                .ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetData")]
        public async Task<IActionResult> getData()
        {
            try
            {
                List<Estoque> lista = await _context.TB_ESTOQUE
                    .OrderByDescending(e => e.Ultima_Atualizacao)  
                    .ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddEstoque(Estoque novoEstoque)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
                .FirstOrDefaultAsync(p => p.Id == novoEstoque.Id_Produto);

                novoEstoque.Produto = produto;

                await _context.TB_ESTOQUE.AddAsync(novoEstoque);
                await _context.SaveChangesAsync();

                string mensagem = $"Estoque adiciona ao Sistema com o Id: {novoEstoque.Id}";

                return Ok(mensagem);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> PutEstoque(Estoque e)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
              .FirstOrDefaultAsync(p => p.Id == e.Id_Produto);

                e.Produto = produto;
                _context.TB_ESTOQUE.Update(e);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelteEstoque(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Estoque estoque = await _context.TB_ESTOQUE
                .FirstOrDefaultAsync(e => e.Id == id);

                if (estoque == null)
                    throw new Exception("ID não encontrado.");


                _context.TB_ESTOQUE.Remove(estoque);
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