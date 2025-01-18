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
    }
}