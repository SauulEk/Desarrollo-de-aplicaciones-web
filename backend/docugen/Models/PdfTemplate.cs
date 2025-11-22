using System.ComponentModel.DataAnnotations;

namespace docugen.Models;

//Modelo para plantillas de CV
public class PdfTemplate
{
    [Key]
    public int id { get; set; }

    [Required]
    public required string name { get; set; }

    [Required]
    public required string content { get; set; }
}
