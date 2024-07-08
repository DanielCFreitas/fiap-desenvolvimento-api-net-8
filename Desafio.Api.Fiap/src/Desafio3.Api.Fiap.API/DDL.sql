CREATE TABLE "Funcionario" (
	"Id" UUID NOT NULL,
	"Nome" VARCHAR(30),
	"Idade" INT4,
	"Pais" VARCHAR(50),
	CONSTRAINT Funcionario_PK PRIMARY KEY ("Id")
)

CREATE TABLE "Endereco" (
	"Id" UUID NOT NULL,
	"Rua" VARCHAR(256),
	"Numero" INT4,
	"CEP" VARCHAR(13),
	"Cidade" VARCHAR(100),
	"Estado" VARCHAR(2),
	"FuncionarioId" UUID NOT NULL,
	CONSTRAINT Endereco_PK PRIMARY KEY ("Id"),
	CONSTRAINT Funcionario_FK FOREIGN KEY ("FuncionarioId") REFERENCES "Funcionario" ("Id")
);