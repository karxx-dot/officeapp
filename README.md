# OfficeApp - Arquitectura en capas

Sistema de gestion de oficina (RR.HH., inventario, operaciones y documentos) en ASP.NET Core MVC con tres capas:
**Web -> BL -> DAL -> SQL Server**.

```
OfficeApp.sln
|-- OfficeApp.BL                      (Capa de negocio)
|   |-- Services/
|   |   |-- HR/  Inventory/  Operations/  Documents/
|   `-- DependencyInjection.cs
|-- OfficeApp.DAL                     (Capa de acceso a datos)
|   |-- Data/OfficeDbContext.cs
|   |-- Models/
|   |   |-- HR/  Inventory/  Operations/  Documents/
|   |-- Repositories/
|   |   |-- Base/  HR/  Inventory/  Operations/  Documents/
|   |-- DependencyInjection.cs
|   `-- efpt.config.json
|-- OfficeApp.Web                     (ASP.NET Core MVC)
|   |-- Controllers/  Views/  wwwroot/
|   |-- appsettings.json
|   `-- Program.cs
|-- database/OfficeDb.sql
`-- scripts/setup-git.ps1 | setup-git.sh
```

## Capa de datos (schemas y entidades)

| Schema / carpeta | Entidades | Rama del modulo |
|---|---|---|
| **HR** | Department, Position, Employee, Attendance, LeaveRequest | `feature/hr-module` |
| **Inventory** | Category, Supplier, Asset, AssetAssignment | `feature/inventory-module` |
| **Operations** | Room, Reservation, Meeting, MeetingAttendee, TaskItem | `feature/operations-module` |
| **Documents** | DocumentType, Document | `feature/documents-module` |

## Flujo de ramas

- `main`: version estable.
- `develop`: integracion.
- `feature/<modulo>-module`: una rama por modulo (cada integrante trabaja la suya y abre Pull Request hacia `develop`).

| Modulo | Rama | Responsable |
|---|---|---|
| HR | `feature/hr-module` | _Nombre del integrante_ |
| Inventory | `feature/inventory-module` | _Nombre del integrante_ |
| Operations | `feature/operations-module` | _Nombre del integrante_ |
| Documents | `feature/documents-module` | _Nombre del integrante_ |

## Puesta en marcha

1. Abrir `OfficeApp.sln` en Visual Studio 2022+ (.NET 8 SDK).
2. Crear la base de datos con `database/OfficeDb.sql`, **o** con migraciones:
   `dotnet ef migrations add Initial -p OfficeApp.DAL -s OfficeApp.Web` y `dotnet ef database update -p OfficeApp.DAL -s OfficeApp.Web`.
3. Ajustar la cadena de conexion `OfficeDb` en `OfficeApp.Web/appsettings.json`.
4. Ejecutar `OfficeApp.Web`.
