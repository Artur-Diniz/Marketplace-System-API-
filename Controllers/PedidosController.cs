using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidosController(DataContext context)
        {
            _context = context;
        }
    }
}