using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("FornecedorProdutos")]
    public class FornecedorProdutosController : ControllerBase
    {
        private readonly DataContext _context;

        public FornecedorProdutosController(DataContext context)
        {
            _context = context;
        }

        #region Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<Fornecedor_Produto> fornecedor_Produtos = await _context
                .TB_FORNECEDOR_PRODUTO.ToListAsync();

                return Ok(fornecedor_Produtos);

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


                Fornecedor_Produto fornecedor_Produto = await _context
                .TB_FORNECEDOR_PRODUTO.FirstOrDefaultAsync(fp => fp.Id_Produto == id);

                if (fornecedor_Produto == null)
                    throw new Exception("ID não encontrado.");

                return Ok(fornecedor_Produto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Post(Fornecedor_Produto fornecedor_Produto)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
                        .FirstOrDefaultAsync(p => p.Id == fornecedor_Produto.Id_Produto);

                Fornecedores fornecedores = await _context.TB_FORNECEDORES
                         .FirstOrDefaultAsync(p => p.Id == fornecedor_Produto.Id_Fornecedor);

                fornecedor_Produto.Produto = produto;
                fornecedor_Produto.Fornecedores = fornecedores;

                await _context.TB_FORNECEDOR_PRODUTO.AddAsync(fornecedor_Produto);
                await _context.SaveChangesAsync();



                return Ok("Produto vinculado ao fornecedor");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(Fornecedor_Produto forn)
        {
            try
            {
                Produto produto = await _context.TB_PRODUTOS
                      .FirstOrDefaultAsync(p => p.Id == forn.Id_Produto);

                Fornecedores fornecedores = await _context.TB_FORNECEDORES
                         .FirstOrDefaultAsync(p => p.Id == forn.Id_Fornecedor);

                forn.Produto = produto;
                forn.Fornecedores = fornecedores;

                _context.TB_FORNECEDOR_PRODUTO.Update(forn);

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


                Fornecedor_Produto fornecedor_Produto = await _context
                .TB_FORNECEDOR_PRODUTO.FirstOrDefaultAsync(fp => fp.Id_Produto == id);

                if (fornecedor_Produto == null)
                    throw new Exception("ID não encontrado.");

                _context.TB_FORNECEDOR_PRODUTO.Remove(fornecedor_Produto);
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