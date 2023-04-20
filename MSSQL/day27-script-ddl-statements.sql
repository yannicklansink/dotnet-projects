SET NOCOUNT ON; -- globale script instellingen. Nu krijg je geen messages meer. 

USE tempdb;
GO

-- DDL Statements

-- begint met het script om het te wissen. Idopotent
DROP TABLE IF EXISTS Huisdieren;
GO

CREATE TABLE Huisdieren
(
	id int NOT NULL
	, naam nvarchar(50) NOT NULL
);
GO

INSERT INTO Huisdieren
(id, naam)
VALUES
(1, 'Bello')
, (2, 'Kazan')
, (3, 'Ibbeltje')
, (4, 'Mies');
GO

select * from Huisdieren


