using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Produtos")]
    public class ProdutoController : ControllerBase
    {
        private static List<Produto> produtos = new List<Produto>()
        {
            new Produto { Id=1, Nome="Camisa Polo Branca", Codigo= 100001, Categoria_Id=1, Image_Url="camiseta_polo_Preta.com.br",data_criacao=new DateTime(2025,01,15), data_ultimaAlteracao = new DateTime(2025,01,15), Produto_Ativo=true},
            new Produto { Id=2, Nome="Camisa Polo preto ", Codigo= 100001, Categoria_Id=1, Image_Url="camiseta_polo_Branca.com.br",data_criacao=new DateTime(2025,01,15), data_ultimaAlteracao = new DateTime(2025,01,15), Produto_Ativo=true}

        };

        #region  Get

        [HttpGet]
        public IActionResult GetFisrt()
        {
            Produto p = produtos[0];
            return Ok(p);
        }

        [HttpGet("GetAll")]
        public IActionResult getAll()
        {
            return Ok(produtos);
        }

        [HttpGet("id")]
        public IActionResult GetId(int id)
        {
            return Ok(produtos.FirstOrDefault(p => p.Id == id));
        }

        #endregion

        [HttpPost]
        public IActionResult AddProduto(Produto novoProduto)
        {
            produtos.Add(novoProduto);

            novoProduto.data_criacao = DateTime.Now;
            novoProduto.data_ultimaAlteracao = novoProduto.data_criacao;

            string mensagem = $"Produto adiciona ao Sistema com o Id{novoProduto.Id}";
            return Ok(mensagem);
        }

        [HttpPut]
        public IActionResult Update(Produto P)
        {
            Produto prodAlterado = produtos.Find(prod => prod.Id == P.Id);
            prodAlterado.Nome = P.Nome;
            prodAlterado.Categoria_Id = P.Categoria_Id;
            prodAlterado.Codigo = P.Codigo;
            prodAlterado.data_ultimaAlteracao = DateTime.Now;
            prodAlterado.Image_Url = P.Image_Url;
            prodAlterado.Produto_Ativo = P.Produto_Ativo;

            return Ok($"Produto Alterado com sucesso{P}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            produtos.RemoveAll(prod => prod.Id == Id);

            return Ok(produtos);
        }
    }
}