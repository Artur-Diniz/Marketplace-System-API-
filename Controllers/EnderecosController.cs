using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("Endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _context;

        public EnderecoController(DataContext context)
        {
            _context = context;
        }
    }
}