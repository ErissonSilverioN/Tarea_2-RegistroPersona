Create Database RegistroPersona

Create Table Persona(
 PersonaId int Primary Key Identity,
 Nombre varchar(20),
 Telefono varchar(15),
 Cedula varchar(15),
 Direccion varchar(max),
)

Alter Table Persona add FechaNacimiento Datetime