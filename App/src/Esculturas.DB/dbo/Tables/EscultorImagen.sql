CREATE TABLE [dbo].[EscultorImagen]
(
  	[ImagenId]    INT NOT NULL,
    [EscultorId]  INT NOT NULL,
    CONSTRAINT [PK_EscultorImagen] PRIMARY KEY CLUSTERED ([ImagenId] ASC),
    CONSTRAINT [FK_EscultorImagen_Imagen] FOREIGN KEY ([ImagenId]) REFERENCES [dbo].[Imagen]([ImagenId]),
    CONSTRAINT [FK_EscultorImagen_Escultor] FOREIGN KEY ([EscultorId]) REFERENCES [dbo].[Escultor]([EscultorId])
)