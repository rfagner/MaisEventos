CREATE DATABASE MaisEventosDB;
GO

USE MaisEventosDB;
GO

CREATE TABLE Categorias(
	Id INT IDENTITY PRIMARY KEY,
	Categoria NVARCHAR(MAX)
);
GO

CREATE TABLE Usuarios(
	Id INT IDENTITY PRIMARY KEY,
	Nome NVARCHAR(MAX),
	Email NVARCHAR(MAX) NOT NULL,
	Senha NVARCHAR(MAX) NOT NULL
);
GO

CREATE TABLE Eventos(
	Id INT IDENTITY PRIMARY KEY,
	DataHora DATETIME,
	Ativo BIT,
	Preco DECIMAL(6,2), /* 1234,99 */

	/* FKs */
	CategoriaId INT
	FOREIGN KEY (CategoriaId) REFERENCES Categorias (Id)
);
GO

CREATE TABLE UsuarioEvento(
	Id INT IDENTITY PRIMARY KEY,

	/* FKs */
	UsuarioId INT
	FOREIGN KEY (UsuarioId) REFERENCES Usuarios (Id) NOT NULL,

	EventoId INT
	FOREIGN KEY (EventoId) REFERENCES Eventos (Id) NOT NULL
);
GO

/* DML 
INSERT INTO [dbo].[Usuarios]
           ([Nome] ,[Email] ,[Senha])
     VALUES
           ('Paulo Brandao','paulo@email.com','123456789'),
		   ('Priscila','priscila@email.com','369258147'),
		   ('Cristiano','cristiano@email.com','987654321')
GO
*/