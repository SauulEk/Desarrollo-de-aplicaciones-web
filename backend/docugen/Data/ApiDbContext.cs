using docugen.Models;
using Microsoft.EntityFrameworkCore;

//Aqui se registran las clases de datos para las migraciones de las tablas
namespace docugen.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PdfTemplate> pdfTemplates { get; set; }
        public DbSet<CvData> curriculums { get; set; }
        public DbSet<EducacionItem> educacionItems { get; set; }
        public DbSet<HabilidadItem> habilidadItems { get; set; }
        public DbSet<InteresItem> interesItems { get; set; }
        public DbSet<TrabajoItem> trabajoItems { get; set; }
    }
}