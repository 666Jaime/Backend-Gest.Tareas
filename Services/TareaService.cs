using Back_Tareas.Data;
using Back_Tareas.DTOs;
using Back_Tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_Tareas.Services;

public sealed class TareaService(AppDbContext context) : ITareaService
{
    public async Task<List<TareaResponseDto>> ObtenerTodasAsync(CancellationToken cancellationToken)
    {
        return await context.Tareas
            .AsNoTracking()
            .OrderBy(tarea => tarea.Id)
            .Select(tarea => Convertir(tarea))
            .ToListAsync(cancellationToken);
    }

    public async Task<TareaResponseDto?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken)
    {
        var tarea = await context.Tareas
            .AsNoTracking()
            .FirstOrDefaultAsync(tarea => tarea.Id == id, cancellationToken);

        return tarea is null ? null : Convertir(tarea);
    }

    public async Task<TareaResponseDto> CrearAsync(
        CrearTareaRequestDto request,
        CancellationToken cancellationToken)
    {
        var tarea = new Tarea
        {
            Titulo = request.Titulo,
            Descripcion = request.Descripcion,
            FechaVencimiento = request.FechaVencimiento
        };

        context.Tareas.Add(tarea);
        await context.SaveChangesAsync(cancellationToken);

        return Convertir(tarea);
    }

    public async Task<TareaResponseDto?> ActualizarAsync(
        int id,
        ActualizarTareaRequestDto request,
        CancellationToken cancellationToken)
    {
        var tarea = await context.Tareas.FindAsync([id], cancellationToken);
        if (tarea is null)
        {
            return null;
        }

        tarea.Titulo = request.Titulo;
        tarea.Descripcion = request.Descripcion;
        tarea.FechaVencimiento = request.FechaVencimiento;
        tarea.Completada = request.Completada;

        await context.SaveChangesAsync(cancellationToken);
        return Convertir(tarea);
    }

    public async Task<bool> EliminarAsync(int id, CancellationToken cancellationToken)
    {
        var tarea = await context.Tareas.FindAsync([id], cancellationToken);
        if (tarea is null)
        {
            return false;
        }

        context.Tareas.Remove(tarea);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static TareaResponseDto Convertir(Tarea tarea) =>
        new(
            tarea.Id,
            tarea.Titulo,
            tarea.Descripcion,
            tarea.FechaCreacion,
            tarea.FechaVencimiento,
            tarea.Completada);
}
