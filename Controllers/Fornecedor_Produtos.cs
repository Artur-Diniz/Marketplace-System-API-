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
    }
}