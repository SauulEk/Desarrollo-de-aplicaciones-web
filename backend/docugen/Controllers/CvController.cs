using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using docugen.Data;
using docugen.Models;

namespace docugen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CvController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CvController(ApiDbContext context)
        {
            _context = context;
        }

        // Extrae el id del usuario del token JWT
        private int GetCurrentUserId()
        {
            var idClaim = User.FindFirst("id") ?? User.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim != null && int.TryParse(idClaim.Value, out int userId))
            {
                return userId;
            }

            throw new UnauthorizedAccessException("User ID could not be found in the token.");
        }

        // GET: api/Cv
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CvData>>> GetCvs()
        {
            int userId = GetCurrentUserId();

            return await _context.curriculums
                .Where(c => c.userId == userId)
                .Include(c => c.Educacion)
                .Include(c => c.Trabajo)
                .Include(c => c.Habilidades)
                .Include(c => c.Intereses)
                .ToListAsync();
        }

        // GET: api/Cv/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CvData>> GetCvData(int id)
        {
            int userId = GetCurrentUserId();

            var cvData = await _context.curriculums
                .Include(c => c.Educacion)
                .Include(c => c.Trabajo)
                .Include(c => c.Habilidades)
                .Include(c => c.Intereses)
                .FirstOrDefaultAsync(c => c.id == id);

            if (cvData == null)
            {
                return NotFound();
            }

            if (cvData.userId != userId)
            {
                return NotFound();
            }

            return cvData;
        }

        // POST: api/Cv
        [HttpPost]
        public async Task<ActionResult<CvData>> PostCvData(CvData cvData)
        {
            int userId = GetCurrentUserId();

            cvData.userId = userId;

            cvData.user = null;
            cvData.Template = null;

            _context.curriculums.Add(cvData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCvData", new { id = cvData.id }, cvData);
        }

        // PUT: api/Cv/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCvData(int id, CvData cvData)
        {
            if (id != cvData.id) return BadRequest("ID mismatch");

            int userId = GetCurrentUserId();

            var existingCv = await _context.curriculums
                .Include(c => c.Educacion)
                .Include(c => c.Trabajo)
                .Include(c => c.Habilidades)
                .Include(c => c.Intereses)
                .FirstOrDefaultAsync(c => c.id == id);

            if (existingCv == null) return NotFound();

            if (existingCv.userId != userId)
            {
                return NotFound();
            }

            existingCv.templateId = cvData.templateId;
            // No se actualiza userId
            existingCv.Nombre = cvData.Nombre;
            existingCv.Ocupacion = cvData.Ocupacion;
            existingCv.Email = cvData.Email;
            existingCv.Telefono = cvData.Telefono;
            existingCv.Direccion = cvData.Direccion;

            _context.RemoveRange(existingCv.Educacion ?? new List<EducacionItem>());
            existingCv.Educacion = cvData.Educacion;

            _context.RemoveRange(existingCv.Trabajo ?? new List<TrabajoItem>());
            existingCv.Trabajo = cvData.Trabajo;

            _context.RemoveRange(existingCv.Habilidades ?? new List<HabilidadItem>());
            existingCv.Habilidades = cvData.Habilidades;

            _context.RemoveRange(existingCv.Intereses ?? new List<InteresItem>());
            existingCv.Intereses = cvData.Intereses;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CvDataExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Cv/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCvData(int id)
        {
            int userId = GetCurrentUserId();

            var cvData = await _context.curriculums.FindAsync(id);

            if (cvData == null) return NotFound();

            if (cvData.userId != userId)
            {
                return NotFound();
            }

            _context.curriculums.Remove(cvData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CvDataExists(int id)
        {
            return _context.curriculums.Any(e => e.id == id);
        }
    }
}