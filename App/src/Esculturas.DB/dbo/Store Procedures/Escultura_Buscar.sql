CREATE PROCEDURE dbo.Escultura_Buscar(
	@TextoABuscar VARCHAR(100),
	@ColumnaParaOrdenar VARCHAR(100) = 'TITULO ASC',
	@PageIndex INT = 1,
	@PageSize INT = 10
)
AS 
BEGIN

	DECLARE @FirstRow INT = (@PageIndex - 1) * @PageSize


	SELECT 
			E.EsculturaId,
			E.Titulo,
			E.Descripcion,
			E.Tematica,

			--Escultor
			EscultorId = ETOR.EscultorId,
			EscultorNombre = ETOR.Nombre,
			EscultorApellido = ETOR.Apellido,
			EscultorNacionalidad = ETOR.Nacionalidad,

			--Imagen
			ImagenId = IMG.ImagenId,
			ImagenArchivoNombre = IMG.ArchivoNombre,
			ImagenNombre = IMG.Nombre,

			RowIndex = ROW_NUMBER() OVER (ORDER BY 
													(CASE UPPER(@ColumnaParaOrdenar)
														WHEN 'TITULO ASC' THEN E.Titulo
														WHEN 'ESCULTOR ASC' THEN ETOR.Nombre
													 END) ASC,
													 (CASE UPPER(@ColumnaParaOrdenar)
														WHEN 'TITULO DESC' THEN E.Titulo
														WHEN 'ESCULTOR DESC' THEN ETOR.Nombre
													 END) DESC
								),
			RowTotalCount = COUNT(*) OVER()

	FROM dbo.Escultura E
	   LEFT JOIN dbo.EsculturaImagen EI
			ON E.EsculturaId = EI.EsculturaId
	   LEFT JOIN dbo.Imagen IMG
			ON EI.ImagenId = IMG.ImagenId
	   LEFT JOIN dbo.EscultorEscultura EE
			ON E.EsculturaId = EE.EsculturaId
	   LEFT JOIN dbo.Escultor ETOR
			ON EE.EscultorId = ETOR.EscultorId

	WHERE
		(@TextoABuscar IS NULL	
			OR @TextoABuscar = ''
			OR E.Titulo LIKE '%'+@TextoABuscar+'%')

	ORDER BY RowIndex
	OFFSET @FirstRow ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO
/*
----------------------------------------------------------
-- TEST
----------------------------------------------------------

EXEC dbo.Escultura_Buscar
	@TextoABuscar = 'data',
	@ColumnaParaOrdenar = 'ESCULTOR DESC', --ESCULTOR TITULO
	@PageIndex = 1,
	@PageSize = 6


EXEC dbo.Escultura_Buscar
	@TextoABuscar = 'data'


----------------------------------------------------------
*/