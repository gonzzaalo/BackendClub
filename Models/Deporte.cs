using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

public class Deporte
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200, ErrorMessage = "La descripción no puede superar los 200 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    public TimeSpan Hora { get; set; }

    // Relación con Profesor (Muchos a Uno)
    public int ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }

    // Relación con Deportistas (Uno a Muchos)
    public ICollection<Deportista> Deportistas { get; set; } = new List<Deportista>();

    public override string ToString()
    {
        return Nombre;
    }
}
