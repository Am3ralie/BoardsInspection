using BoardsInspection.Core.Entities;
using BoardsInspection.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoardsInspection.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetAll()
        {
            return await _context.Tests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetById(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null) return NotFound();
            return test;
        }

        [HttpPost]
        public async Task<ActionResult<Test>> Create(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = test.Id }, test);
        }
    }
}
