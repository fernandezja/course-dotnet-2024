CREATE TABLE [dbo].[Evento]
(
  [EventoId]        INT IDENTITY(1,1) NOT NULL,
	[Nombre]          VARCHAR(200) NOT NULL,
	[FechaInicio]     DATETIME2(0) NOT NULL,
	[FechaFin]        DATETIME2(0) NULL,
	[Ubicacion]       VARCHAR(100) NULL,
  CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([EventoId] ASC)
)

