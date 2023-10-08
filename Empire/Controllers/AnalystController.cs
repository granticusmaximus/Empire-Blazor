using Empire.Data;
using Empire.Models;
using Empire.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Empire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalystController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AnalystService _service;

        public AnalystController(ApplicationDbContext context, AnalystService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<List<Analyst>> Get()
        {
            return await Task.FromResult(_service.GetAnalystAsList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Analyst analyst = _service.GetAnalystData(id);
            if (analyst != null)
            {
                return Ok(analyst);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Analyst analyst)
        {
            _service.AddAnalyst(analyst);
        }

        [HttpPut]
        public void Put(Analyst analyst)
        {
            _service.UpdateAnalystDetails(analyst);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAnalyst(id);
            return Ok();
        }
    }
}
