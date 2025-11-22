using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace docugen.Models;

//Los json de datos para CVs se convierten en CvData para ser procesados e insertados al html
public class CvData
{
    [Key]
    public int id { get; set; }
    public int templateId { get; set; }
    [ForeignKey("templateId")]
    public PdfTemplate? Template { get; set; }
    public int userId { get; set; }
    [ForeignKey("userId")]
    public User? user { get; set; }
    public string? Nombre { get; set; }
    public string? Ocupacion { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public List<EducacionItem>? Educacion { get; set; }
    public List<TrabajoItem>? Trabajo { get; set; }
    public List<HabilidadItem>? Habilidades { get; set; }
    public List<InteresItem>? Intereses { get; set; }
}

public class EducacionItem
{
    [Key]
    public int id { get; set; }
    public string? Institucion { get; set; }
    public string? Fecha_Graduacion { get; set; }
    public string? Carrera { get; set; }
}

public class TrabajoItem
{
    [Key]
    public int id { get; set; }
    public string? Empresa { get; set; }
    public string? Fecha_Inicio { get; set; }
    public string? Fecha_Final { get; set; }
    public string? Puesto { get; set; }
}

public class HabilidadItem
{
    [Key]
    public int id { get; set; }
    public string? Habilidad { get; set; }
}

public class InteresItem
{
    [Key]
    public int id { get; set; }
    public string? Interes { get; set; }
}
