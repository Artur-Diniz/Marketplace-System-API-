using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("ClienteCpf")]
    public class Cliente_CpfController : ControllerBase
    {
        private readonly DataContext _context;

        public Cliente_CpfController(DataContext context)
        {
            _context = context;
        }
    }
}