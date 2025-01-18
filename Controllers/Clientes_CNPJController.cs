using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("ClienteCnpj")]
    public class Cliente_CnpjController : ControllerBase
    {
        private readonly DataContext _context;

        public Cliente_CnpjController(DataContext context)
        {
            _context = context;
        }
    }
}