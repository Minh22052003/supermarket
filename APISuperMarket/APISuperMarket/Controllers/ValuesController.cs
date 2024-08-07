using APISuperMarket.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataSuperMartContext _context;

        public ValuesController(DataSuperMartContext context)
        {
            _context = context;
        }
        [HttpGet]   
        public IActionResult GetAll()
        {
            return Ok(_context.Categories.ToList());
        }
    }
}
