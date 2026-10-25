using System.ComponentModel.DataAnnotations;

namespace Back_Tareas.DTOs;

/// <summary>Datos necesarios para crear una tarea.</summary>
public sealed record CrearTareaRequestDto
{
    [Required, StringLength(150)]
    public required string Titulo { get; init; }

    [StringLength(1000)]
    public string? Descripcion { get; init; }

    public DateTimeOffset? FechaVencimiento { get; init; }
}
