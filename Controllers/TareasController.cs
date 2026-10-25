using Back_Tareas.DTOs;
using Back_Tareas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Back_Tareas.Controllers;

[ApiController]
[Route("api/v1/tareas")]
public sealed class TareasController(ITareaService tareaService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TareaResponseDto>>> ObtenerTodas(
        CancellationToken cancellationToken)
    {
        return Ok(await tareaService.ObtenerTodasAsync(cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TareaResponseDto>> ObtenerPorId(
        int id,
        CancellationToken cancellationToken)
    {
        var tarea = await tareaService.ObtenerPorIdAsync(id, cancellationToken);
        return tarea is null ? NotFound() : Ok(tarea);
    }

    [HttpPost]
    public async Task<ActionResult<TareaResponseDto>> Crear(
        CrearTareaRequestDto request,
        CancellationToken cancellationToken)
    {
        var tarea = await tareaService.CrearAsync(request, cancellationToken);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = tarea.Id }, tarea);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TareaResponseDto>> Actualizar(
        int id,
        ActualizarTareaRequestDto request,
        CancellationToken cancellationToken)
    {
        var tarea = await tareaService.ActualizarAsync(id, request, cancellationToken);
        return tarea is null ? NotFound() : Ok(tarea);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar(int id, CancellationToken cancellationToken)
    {
        var eliminado = await tareaService.EliminarAsync(id, cancellationToken);
        return eliminado ? NoContent() : NotFound();
    }
}
