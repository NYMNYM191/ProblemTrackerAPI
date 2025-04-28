using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProblemTrackerAPI.Data;
using ProblemTrackerAPI.Models;

namespace ProblemTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProblemsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Problem>>> GetProblems()
        {
            return await _context.Problems.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Problem>> GetProblem(int id)
        {
            var problem = await _context.Problems.FindAsync(id);
            return problem == null ? NotFound() : problem;
        }

        [HttpPost]
        public async Task<ActionResult<Problem>> PostProblem(Problem problem)
        {
            _context.Problems.Add(problem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProblem), new { id = problem.Id }, problem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblem(int id, Problem problem)
        {
            if (id != problem.Id) return BadRequest();

            _context.Entry(problem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblem(int id)
        {
            var problem = await _context.Problems.FindAsync(id);
            if (problem == null) return NotFound();

            _context.Problems.Remove(problem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
