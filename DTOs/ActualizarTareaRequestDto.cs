using System.ComponentModel.DataAnnotations;

namespace Back_Tareas.DTOs;

/// <summary>Datos para actualizar una tarea existente.</summary>
public sealed record ActualizarTareaRequestDto
{
    [Required, StringLength(150)]
    public required string Titulo { get; init; }

    [StringLength(1000)]
    public string? Descripcion { get; init; }

    public DateTimeOffset? FechaVencimiento { get; init; }

    public bool Completada { get; init; }
}
