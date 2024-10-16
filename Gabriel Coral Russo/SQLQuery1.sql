CREATE DATABASE dev_db

USE dev_db

CREATE TABLE Professores(
ProfessorId INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255),
Email VARCHAR(255),
Senha VARCHAR(255)
)

CREATE TABLE Turmas(
TurmaId INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255),
ProfessorId INT,
FOREIGN KEY(ProfessorId) REFERENCES Professores(ProfessorId)
)

CREATE TABLE Atividades(
AtividadeId INT PRIMARY KEY IDENTITY,
Descricao VARCHAR(255),
TurmaId INT,
FOREIGN KEY(TurmaId) REFERENCES Turmas(TurmaId)
)

INSERT INTO Professores(Nome, Email, Senha)
VALUES('João Oliveira', 'joliveira@gmail.com', 'admin1234'),
('Jorge Aragão', 'jaragão@gmail.com', 'admin1234'),
('Beatriz Lima', 'blima@gmail.com', 'admin1234')


INSERT INTO Turmas(Nome, ProfessorId)
VALUES ('Desenvolvimento', 1),
('Multimidia', 2),
('Redes', 3)

INSERT INTO Atividades (Descricao, TurmaId)
VALUES( 'Simulado com MVC', 4),
( 'Identidade Visual', 5),
( 'CTF', 6)

CREATE USER [INFOLOCAL\23655858841] FOR LOGIN [INFOLOCAL\23655858841];
ALTER ROLE db_owner ADD MEMBER [INFOLOCAL\23655858841];