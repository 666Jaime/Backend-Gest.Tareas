using Back_Tareas.DTOs;

namespace Back_Tareas.Services;

public interface ITareaService
{
    Task<List<TareaResponseDto>> ObtenerTodasAsync(CancellationToken cancellationToken);
    Task<TareaResponseDto?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken);
    Task<TareaResponseDto> CrearAsync(CrearTareaRequestDto request, CancellationToken cancellationToken);
    Task<TareaResponseDto?> ActualizarAsync(int id, ActualizarTareaRequestDto request, CancellationToken cancellationToken);
    Task<bool> EliminarAsync(int id, CancellationToken cancellationToken);
}
