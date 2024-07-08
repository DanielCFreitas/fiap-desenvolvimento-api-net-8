CREATE TABLE "Funcionario" (
	"Id" UUID NOT NULL,
	"Nome" VARCHAR(30),
	"Idade" INT4,
	"Pais" VARCHAR(50),
	CONSTRAINT Funcionario_PK PRIMARY KEY ("Id")
);