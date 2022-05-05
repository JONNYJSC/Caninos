
CREATE PROCEDURE AddCanino
	@NombreCanino VARCHAR(50),
	@Raza VARCHAR(30),
	@EdadCanina int
AS
BEGIN
INSERT INTO Canino(
NombreCanino,
Raza,
EdadCanina
) VALUES (@NombreCanino, @Raza,@EdadCanina)
END
GO

CREATE PROCEDURE GetCaninos
AS
BEGIN
SELECT * FROM Canino
END
GO

CREATE PROC DeleteCanino
@Id INT 
AS 
BEGIN 
	DELETE FROM Canino WHERE Id = @Id
END
GO	

CREATE PROC UpdateCanino
	@Id INT,
	@NombreCanino VARCHAR(50),
	@Raza VARCHAR(30),
	@EdadCanina int
AS
BEGIN
UPDATE Canino
SET 
	NombreCanino = @NombreCanino,
	Raza = @Raza,
	EdadCanina = @EdadCanina 
		WHERE Id  = @Id
END
GO

EXEC dbo.GetCaninos