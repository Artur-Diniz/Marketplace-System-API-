using marktplace_sistem.Data;
using marktplace_sistem.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marktplace_sistem.Controllers
{
    [ApiController]
    [Route("HistoricoPrecos")]
    public class HistoricoPrecosController : ControllerBase
    {
        private readonly DataContext _context;

        public HistoricoPrecosController(DataContext context)
        {
            _context = context;
        }
    }
}