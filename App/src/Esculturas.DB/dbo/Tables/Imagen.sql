CREATE TABLE [dbo].[Imagen]
(
    [ImagenId]        INT IDENTITY(1,1) NOT NULL,
    [Nombre]          VARCHAR(200) NOT NULL,
    [ArchivoNombre]   VARCHAR(1000) NOT NULL,
    CONSTRAINT [PK_ImagenId] PRIMARY KEY CLUSTERED ([ImagenId] ASC)
)