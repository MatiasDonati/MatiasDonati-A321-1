-- Crea la base de datos
CREATE DATABASE lab_sp
GO
-- Usar base de datos creada
USE lab_sp
GO

-- Crear tabla patentes
CREATE TABLE patentes(
	id INT IDENTITY(1,1) PRIMARY KEY,
	patente VARCHAR(50),
	tipo VARCHAR(50)
)
GO

-- Insertar registros
INSERT INTO patentes (patente, tipo)
VALUES ('AJ123DC','Mercosur'),
		('AS123GH','Mercosur'),
		('ASD123','Vieja')
		


