using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context)
        {
            _context = context;
        }


        #region  Get

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .ToListAsync();

                return Ok(lista);

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
                {
                    throw new Exception("O ID não pode ser igual Zero.");
                }

                Produto prod = await _context.TB_PRODUTOS
                .Include(c => c.categoria)
                .Include(i => i.Impostos)
                .Include(it => it.Itens_Pedidos)
                .Include(c => c.Compras)
                .Include(hi => hi.Historico_Precos)
                .Include(l => l.Lucros)
                .Include(p => p.Precos)
                .Include(e => e.Estoque)
                .FirstOrDefaultAsync(p => p.Id == id);

                //categoria, Impostos, Itens_Pedidos,Compras,Historico_Precos,Lucros,Precos,Estoque
                // Estoque categoria


                if (prod == null)
                {
                    throw new Exception("ID não encontrado.");
                }

                return Ok(prod);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> AddProduto(Produto novoProduto)
        {
            try
            {
                novoProduto.data_criacao = DateTime.Now;
                novoProduto.data_ultimaAlteracao = novoProduto.data_criacao;


                Estoque estoque = await _context.TB_ESTOQUE
                .FirstOrDefaultAsync(e => e.Id == novoProduto.Id_Estoque);
                novoProduto.Estoque = estoque;

                Categoria categoria = await _context.TB_CATEGORIAS
                .FirstOrDefaultAsync(e => e.Id == novoProduto.Id_categoria);
                novoProduto.categoria = categoria;


                await _context.TB_PRODUTOS.AddAsync(novoProduto);
                await _context.SaveChangesAsync();

                string mensagem = $"Produto adiciona ao Sistema com o Id{novoProduto.Id}";
                return Ok(mensagem);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Produto P)
        {
            try
            {

                Estoque estoque = await _context.TB_ESTOQUE
                .FirstOrDefaultAsync(e => e.Id == P.Id_Estoque);
                P.Estoque = estoque;

                Categoria categoria = await _context.TB_CATEGORIAS
                .FirstOrDefaultAsync(e => e.Id == P.Id_categoria);
                P.categoria = categoria;

                
                _context.TB_PRODUTOS.Update(P);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (Id == 0)
                    throw new Exception("O ID não pode ser igual Zero.");

                Produto produto = await _context.TB_PRODUTOS.FirstOrDefaultAsync(prod => prod.Id == Id);

                if (produto == null)
                    throw new Exception("ID não encontrado.");


                _context.TB_PRODUTOS.Remove(produto);
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