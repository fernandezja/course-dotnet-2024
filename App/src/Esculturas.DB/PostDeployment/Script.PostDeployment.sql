-- This file contains SQL statements that will be executed after the build script.

PRINT 'Populando escultores...'
GO

INSERT INTO dbo.Escultor
(Nombre, Apellido, Nacionalidad)
SELECT TOP 5000
	Nombre = CONCAT('Nombre ', C1.[name]), 
	Apellido = CONCAT('Ape ', C1.[name]),  
	Nacionalidad = 'ARG'
FROM sys.all_columns C1
GO


INSERT INTO dbo.Escultura
([Titulo], [Descripcion], [Tematica])
SELECT TOP 5000
	Titulo = CONCAT('Escultura ', C1.[name]), 
	Descripcion = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer convallis ullamcorper turpis, nec aliquet diam vehicula sed. Curabitur aliquam sollicitudin tortor eget aliquam. Praesent molestie elit eget ex maximus pharetra. Aliquam faucibus diam nibh, nec rutrum augue malesuada ut. Donec nunc risus, congue rhoncus gravida vitae, viverra non libero. In auctor iaculis quam sit amet imperdiet. Quisque felis justo, condimentum cursus velit eu, egestas pulvinar nisl.',  
	Tematica = NULL
FROM sys.all_columns C1
GO


INSERT INTO dbo.EscultorEscultura
([EscultorId], [EsculturaId])
SELECT
	E.EscultorId,
	ESC.EsculturaId
FROM dbo.Escultor E
	INNER JOIN dbo.Escultura ESC
		ON E.EscultorId = ESC.EsculturaId
GO





INSERT INTO dbo.Imagen
([Nombre], [ArchivoNombre])
SELECT TOP 1000
	Titulo = CONCAT('Img ', C1.[name]), 
	ArchivoNombre = CONCAT('Path Archivo ', C1.[name])
FROM sys.all_columns C1 
GO

INSERT INTO dbo.EsculturaImagen 
([ImagenId], [EsculturaId])
SELECT 
	ImagenId = IMG.ImagenId,
	[EsculturaId] = IMG.ImagenId
FROM dbo.Imagen IMG
WHERE
	(NOT EXISTS (SELECT TOP 1 1 FROM dbo.EsculturaImagen EI2
					WHERE EI2.ImagenId = IMG.ImagenId))
GO