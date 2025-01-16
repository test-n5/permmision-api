# Permission API

Este proyecto es una API de permisos desarrollada en C# utilizando ASP.NET Core.

## Requisitos previos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (opcional si se desea utilizar la base de datos SQLite)

## Configuración

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/test-n5/permmision-api.git

2. **Restaurar dependencias**
```bash
   cd permission-api
   
   dotnet restore
```
3. **Configurar la base de datos**

- Este proyecto está configurado para usar SQLite por defecto.
- Si deseas usar SQL Server, comenta la configuración de SQLite y descomenta la configuración de SQL Server en Program.cs.

4. **Configurar la base de datos**

Una vez que la aplicación esté en ejecución, abre tu navegador y accede a:
- https://localhost:5001/swagger
- Esto abrirá la interfaz Swagger donde podrás probar y explorar los endpoints de la API.

5. Corre el Proyecto

  ```bash 
    dotnet run
  ```