using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using docugen.Data;
using docugen.Models;
using Microsoft.AspNetCore.Authorization;

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

        // GET: api/Cv
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CvData>>> GetCvs()
        {
            return await _context.curriculums
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

            return cvData;
        }

        // POST: api/Cv
        [HttpPost]
        public async Task<ActionResult<CvData>> PostCvData(CvData cvData)
        {
            // Evitamos crear un usuario y template por accidente.
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
            if (id != cvData.id)
            {
                return BadRequest("ID mismatch");
            }

            var existingCv = await _context.curriculums
                .Include(c => c.Educacion)
                .Include(c => c.Trabajo)
                .Include(c => c.Habilidades)
                .Include(c => c.Intereses)
                .FirstOrDefaultAsync(c => c.id == id);

            if (existingCv == null)
            {
                return NotFound();
            }

            //Update cv
            existingCv.templateId = cvData.templateId;
            existingCv.userId = cvData.userId;
            existingCv.Nombre = cvData.Nombre;
            existingCv.Ocupacion = cvData.Ocupacion;
            existingCv.Email = cvData.Email;
            existingCv.Telefono = cvData.Telefono;
            existingCv.Direccion = cvData.Direccion;

            // Update Education
            _context.RemoveRange(existingCv.Educacion ?? new List<EducacionItem>());
            existingCv.Educacion = cvData.Educacion;

            // Update Work
            _context.RemoveRange(existingCv.Trabajo ?? new List<TrabajoItem>());
            existingCv.Trabajo = cvData.Trabajo;

            // Update Skills
            _context.RemoveRange(existingCv.Habilidades ?? new List<HabilidadItem>());
            existingCv.Habilidades = cvData.Habilidades;

            // Update Interests
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
            var cvData = await _context.curriculums.FindAsync(id);
            if (cvData == null)
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