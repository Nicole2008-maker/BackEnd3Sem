CREATE DATABASE ConnectPlus_Moura;
GO

USE ConnectPlus_Moura;
GO

CREATE TABLE TipoContato(
IdTipoContato    UNIQUEIDENTIFIER  PRIMARY KEY DEFAULT ((NEWID())),
Titulo           NVARCHAR(100)     NOT NULL,
);


CREATE TABLE Contato(
IdUsuario        UNIQUEIDENTIFIER  PRIMARY KEY DEFAULT ((NEWID())),
Nome             NVARCHAR (100)    NOT NULL,
FormaDeContato   VARCHAR  (250)    NOT NULL,
Identificador    VARCHAR  (250)    NOT NULL,
Imagem           NVARCHAR (400)            ,
IdTipoUsuario    UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES TipoContato(IdTipoContato),
);

