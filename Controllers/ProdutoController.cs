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


        [HttpGet("Categoria/{categoria}")]
        public async Task<IActionResult> getAll(int catecategoria)
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .Where(p => p.Id_categoria == catecategoria)
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("Vendas")]
        public async Task<IActionResult> GetVenda()
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .OrderByDescending(p => p.Itens_Pedidos.Count())
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("MaiorPreco")]
        public async Task<IActionResult> GetMaiorPreco()
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .OrderByDescending(p => p.Precos)
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("MenorPreco")]
        public async Task<IActionResult> MenorPreco()
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .OrderBy(p => p.Precos)
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Estoque")]
        public async Task<IActionResult> GetEstoque()
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .OrderByDescending(p => p.Estoque)
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("Cor/{cor}")]
        public async Task<IActionResult> GetCor(string cor)
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .Where(p => p.Cor == cor)
                .ToListAsync();

                return Ok(lista);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Tamanho/{Tamanho}")]
        public async Task<IActionResult> GetTamanho(string tamanho)
        {
            try
            {
                List<Produto> lista = await _context.TB_PRODUTOS
                .Where(p => p.Tamanho == tamanho)
                .ToListAsync();

                return Ok(lista);

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
                List<Produto> lista = await _context.TB_PRODUTOS
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