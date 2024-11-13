CREATE TABLE [dbo].[Escultor]
(
  	[EscultorId]        INT IDENTITY(1,1) NOT NULL,
	[Nombre]            VARCHAR(200) NOT NULL,
	[Apellido]          VARCHAR(200) NOT NULL,
	[Nacionalidad]      VARCHAR(100) NULL,
  CONSTRAINT [PK_Escultor] PRIMARY KEY CLUSTERED ([EscultorId] ASC)
)
