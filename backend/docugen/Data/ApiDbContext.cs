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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- CONFIGURACIÓN DE CASCADE DELETE ---
            // Esto asegura que al borrar un CvData, se borren sus hijos automáticamente

            // 1. Configurar EducacionItems
            modelBuilder.Entity<EducacionItem>()
                .HasOne<CvData>()            // Tiene relación con CvData
                .WithMany()                  // Un CvData tiene muchos de estos
                .HasForeignKey("CvDataid")   // Usamos el nombre exacto que dio el error (shadow property)
                .OnDelete(DeleteBehavior.Cascade);

            // 2. Configurar HabilidadItems
            modelBuilder.Entity<HabilidadItem>()
                .HasOne<CvData>()
                .WithMany()
                .HasForeignKey("CvDataid")
                .OnDelete(DeleteBehavior.Cascade);

            // 3. Configurar InteresItems
            modelBuilder.Entity<InteresItem>()
                .HasOne<CvData>()
                .WithMany()
                .HasForeignKey("CvDataid")
                .OnDelete(DeleteBehavior.Cascade);

            // 4. Configurar TrabajoItems
            modelBuilder.Entity<TrabajoItem>()
                .HasOne<CvData>()
                .WithMany()
                .HasForeignKey("CvDataid")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
