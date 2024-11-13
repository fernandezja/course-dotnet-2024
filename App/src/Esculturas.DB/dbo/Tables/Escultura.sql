CREATE TABLE [dbo].[Escultura]
(
  [EsculturaId]        INT IDENTITY(1,1) NOT NULL,
	[Titulo]             VARCHAR(200) NOT NULL,
	[Descripcion]        VARCHAR(MAX) NULL,
	[Tematica]           VARCHAR(100) NULL,
  CONSTRAINT [PK_Escultura] PRIMARY KEY CLUSTERED ([EsculturaId] ASC)
)
