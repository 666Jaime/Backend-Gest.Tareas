namespace Back_Tareas.DTOs;

/// <summary>Datos de una tarea devueltos por la API.</summary>
public sealed record TareaResponseDto(
    int Id,
    string Titulo,
    string? Descripcion,
    DateTimeOffset FechaCreacion,
    DateTimeOffset? FechaVencimiento,
    bool Completada);
