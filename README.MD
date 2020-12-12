# API do projeto Votador

API criada em C#

# Framework utilizado

- dotNET 5: Foi usado a versão mais nova do dotNET para a criação deste projeto
- flunt: Foi escolhido usar a biblioteca do flunt para que pudesse ser utilizado
  o pattern de Design By Contract.
- Dapper: O Dapper foi usado para a persistência das informações no banco de dados

# Funcionamento da API

- Para o funcionamento da API é necessário um banco de dados PostgreSQL
- Precisa ser criado manualmente as tabelas para o banco de dados como será
  mostrado abaixo:

create DATABASE Votador

create TABLE funcionario (
Id VARCHAR(8) PRIMARY KEY NOT NULL,
Nome VARCHAR(50) NOT NULL,
Email VARCHAR(160) NOT NULL,
Senha VARCHAR(32) NOT NULL
)

create table recurso (
Id VARCHAR(8) PRIMARY KEY NOT NULL,
Titulo VARCHAR(100) NOT NULL,
Descricao VARCAHR(160) NOT NULL
)

CREATE TABLE voto (
Id VARCHAR(8) PRIMARY KEY NOT NULL,
funcionarioId VARCHAR(8) NOT NULL,
recursoId VARCHAR(8) NOT NULL,
horavoto timestamp,
gostei bool,
quantidadevotos int,
FOREIGN KEY (funcionarioId) REFERENCES funcionario(Id),
FOREIGN key (recursoId) REFERENCES recurso(Id)
)

CREATE TABLE comentario (
Id VARCHAR(8) PRIMARY KEY NOT NULL,
recursoId VARCHAR(8) NOT NULL,
funcionarioId VARCHAR(8) NOT NULL,
datavoto timestamp,
descricao VARCHAR(120),
FOREIGN KEY (funcionarioId) REFERENCES funcionario(Id),
FOREIGN key (recursoId) REFERENCES recurso(Id)
)

As configurações de banco de dados e de Secret podem ser alteradas no arquivo Configurações no projeto
Votador.Compartilhado

# Rotas

As rotas da API estão padronizadas da seguinte forma: http://localhost:5000/v1/
onde depois do v1/ basta informar o recurso conforme temos nos Controllers do projeto
Votador.Api
