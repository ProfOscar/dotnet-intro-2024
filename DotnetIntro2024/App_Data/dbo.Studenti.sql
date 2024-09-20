CREATE TABLE [dbo].[Studenti]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NULL, 
    [Cognome] VARCHAR(50) NULL, 
    [Classe] VARCHAR(5) NULL, 
    [AnnoNascita] SMALLINT NULL, 
    [Genere] CHAR(1) NULL
)
