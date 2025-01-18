using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Lucros")]
    public class LucrosController : ControllerBase
    {
        private readonly DataContext _context;

        public LucrosController(DataContext context)
        {
            _context = context;
        }
    }
}