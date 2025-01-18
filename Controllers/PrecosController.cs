using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Precos")]
    public class PrecosController : ControllerBase
    {
        private readonly DataContext _context;

        public PrecosController(DataContext context)
        {
            _context = context;
        }
    }
}