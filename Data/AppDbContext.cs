using Back_Tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_Tareas.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tarea> Tareas => Set<Tarea>();
}
