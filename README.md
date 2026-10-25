# Backend Gestor de Tareas

API REST construida con ASP.NET Core y Entity Framework Core, usando PostgreSQL.

## Requisitos

- .NET 10 SDK
- PostgreSQL

## Configuracion

Configura la cadena de conexion `TareasConnection` mediante la variable de entorno
`ConnectionStrings__TareasConnection`. Por ejemplo, en PowerShell:

```powershell
$env:ConnectionStrings__TareasConnection = "Host=localhost;Port=5433;Database=Tareas;Username=postgres;Password=TU_CLAVE"
```

Como alternativa para desarrollo local, copia `appsettings.example.json` como
`appsettings.json` y edita la cadena de conexion. Ese archivo local esta excluido
de Git para evitar publicar credenciales.

## Ejecutar

Desde la carpeta del proyecto:

```powershell
dotnet restore
dotnet ef database update
dotnet run
```

En Development, la especificacion OpenAPI esta disponible en `/openapi/v1.json`.

## Endpoints

Todos los endpoints usan la ruta base `/api/v1/tareas`:

| Metodo | Ruta | Accion |
| --- | --- | --- |
| GET | `/api/v1/tareas` | Listar tareas |
| GET | `/api/v1/tareas/{id}` | Obtener una tarea |
| POST | `/api/v1/tareas` | Crear una tarea |
| PUT | `/api/v1/tareas/{id}` | Actualizar una tarea |
| DELETE | `/api/v1/tareas/{id}` | Eliminar una tarea |
