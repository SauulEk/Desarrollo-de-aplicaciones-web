using Microsoft.AspNetCore.Mvc;
using docugen.Data;
using Microsoft.EntityFrameworkCore;
using docugen.Models;
using Microsoft.AspNetCore.Authorization;

namespace docugen
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PdfController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PdfController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost("generate/{id}")]
        public async Task<IActionResult> GetDocument(int id)
        {
            CvData? cvData = await _context.curriculums
                .Include(c => c.Educacion)
                .Include(c => c.Trabajo)
                .Include(c => c.Habilidades)
                .Include(c => c.Intereses)
                .Include(c => c.Template)
                .FirstOrDefaultAsync(c => c.id == id);

            if (cvData == null)
            {
                return NotFound($"CV with ID {id} not found.");
            }

            if (cvData.Template == null || string.IsNullOrEmpty(cvData.Template.content))
            {
                return BadRequest("The selected CV does not have a valid PDF Template assigned.");
            }

            PdfService pdfService = new PdfService();

            Stream stream = await pdfService.RetrievePdf(cvData.Template.content, cvData);

            return File(stream, "application/pdf", $"cv_{cvData.id}.pdf");
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListTemplates()
        {
            var allTemplates = await _context.pdfTemplates.ToListAsync();
            return Ok(allTemplates);
        }
    }
}
