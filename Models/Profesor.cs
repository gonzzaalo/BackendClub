using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Profesor
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Apellido { get; set; } = string.Empty;

    [Phone]
    public string Telefono { get; set; } = string.Empty;

    // Relación con Deportes (Uno a Muchos)
    public ICollection<Deporte>? Deportes { get; set; }

    public override string ToString()
    {
        return $"{Nombre} {Apellido}";
    }
}
