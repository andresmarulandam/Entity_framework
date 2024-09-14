## Fundamentos de Entity Framework

1. Instalar .net SDK si no está instalado, se puede probar con el comando dotnet --version
2. Colocarlo en el path de las variables.
3. Iniciar proyecto con dotnet new web

# NuGet: administrador de paquetes para .NET

# Instalación de librerías necesarias para el proyecto

1. En nuGet buscar Entity Microsoft.EntityFrameworkCore, seleccionar la versión más estable al momento, no las preview
2. Escribir en consola la linea que nos da nuget en este caso: dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
3. En nuGet buscar: Microsoft.EntityFrameworkCore.InMemory
4. Escribir en consola la linea que nos da nuGet: dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 8.0.8
5. Buscar en nuGet: Microsoft.EntityFrameworkCore.SqlServer
6. Escribir en consola la linea que nos da nuGet: dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.8

# CREACIÓN DE MODELOS:

1. Crear carpeta en la raíz llamada Models
2. Dentro de la carpeta Models crear un archivo llamado Categoria.cs

# Configuración de Entity Framework

1. Crear un archivo terminado en context.cs en este caso TareaContext.cs
2. En ese archivo se hará la configuración de Entity Framework

# Mapeo de modelos usando atributos

1. Dentro de los models: con los data notacion o atributos como key se sabe que categoriaId sera la primary key

- [ForeignKey("CategoriaId")]
- [Required]
- [MaxLength(200)]
- [NotMapped]: Se genera en memoria y no en la base de datos

# Utilizando base de datos en memoria

1. Ir a Program.cs donde estará la configuración del proyecto
2. Para generar la base de datos en memoria por medio de Entity Framework.
3. En terminal: dotnet build
4. En terminal dotnet run
5. En postman, probar con el local host que salga en el terminal mas /dbconexion

# Conectado a base de datos SQL server

1. Configurar AddSqlServer para conectar a la base de datos a SQLServer en el Program.cs
2. En este caso yo usé la configuración de seguridad de Windows
3. dotnet new gitignore

# Agregando conexión al archivo appsettings

1. En el archivo appsettings.json colocar: ConnectionStrings y pasar la linea de conexion a la db.
2. Luego en Program.cs : builder.Configuration.GetConnectionString("conexionTareas")
