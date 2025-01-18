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
    }
}