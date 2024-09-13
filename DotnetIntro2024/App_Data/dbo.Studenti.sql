CREATE TABLE [dbo].[Studenti]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NULL, 
    [Cognome] VARCHAR(50) NULL, 
    [Classe] INT NULL, 
    [AnnoNascita] SMALLINT NULL, 
    [Genere] CHAR(1) NULL
)
