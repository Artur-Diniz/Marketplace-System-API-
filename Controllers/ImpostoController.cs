using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Impostos")]
    public class ImpostosController : ControllerBase
    {
        private readonly DataContext _context;

        public ImpostosController(DataContext context)
        {
            _context = context;
        }
    }
}