# PruebaTecnicaML
Prueba tecnica felipe mosquera 
# Cambiar Connection String
startup.cs en la linea 27 cambiar datos de la cadena de conexion por la local
# Instalar dotnet tool
```bash
dotnet tool install --global dotnet-ef --version 6.0.5
```
herramienta que sirve para manejar las migraciones
verificar que quedo instalada con el comando 
```bash
dotnet ef
```
# Migracion de la base de datos 
actualizamos la base de datos con
```bash
dotnet ef database update
```
Despues dejamos la base de datos en una version especifica ya creada con 
```bash
dotnet ef database update initial
```
# Ejecutar el proyecto
```bash
dotnet run
```
vemos el swagger en http://localhost:5001/swagger/index.html
