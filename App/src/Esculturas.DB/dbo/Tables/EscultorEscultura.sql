CREATE TABLE [dbo].[EscultorEscultura]
(
  	[EscultorEsculturaId] INT IDENTITY(1,1) NOT NULL,
    [EscultorId]          INT NOT NULL,
    [EsculturaId]         INT NOT NULL,
    CONSTRAINT [PK_EscultorEsculturaId] PRIMARY KEY CLUSTERED ([EscultorEsculturaId] ASC),
    CONSTRAINT [FK_EscultorEscultura_Escultor] FOREIGN KEY ([EscultorId]) REFERENCES [dbo].[Escultor]([EscultorId]),
    CONSTRAINT [FK_EscultorEscultura_Escultura] FOREIGN KEY ([EsculturaId]) REFERENCES [dbo].[Escultura]([EsculturaId])
)