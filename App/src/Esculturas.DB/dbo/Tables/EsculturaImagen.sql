CREATE TABLE [dbo].[EsculturaImagen]
(
    [ImagenId]    INT NOT NULL,
    [EsculturaId]  INT NOT NULL,
    CONSTRAINT [PK_EsculturaImagen] PRIMARY KEY CLUSTERED ([ImagenId] ASC),
    CONSTRAINT [FK_EsculturaImagen_Imagen] FOREIGN KEY ([ImagenId]) REFERENCES [dbo].[Imagen]([ImagenId]),
    CONSTRAINT [FK_EsculturaImagen_Escultura] FOREIGN KEY ([EsculturaId]) REFERENCES [dbo].[Escultura]([EsculturaId])
)