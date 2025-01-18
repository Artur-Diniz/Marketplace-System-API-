using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Comrpas")]
    public class ComprasController : ControllerBase
    {
        private readonly DataContext _context;

        public ComprasController(DataContext context)
        {
            _context = context;
        }
    }
}