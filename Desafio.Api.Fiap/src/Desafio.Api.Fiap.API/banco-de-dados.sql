CREATE TABLE "Produtos" (
	"Id" UUID NOT NULL,
	"Nome" VARCHAR(100),
	"Preco" NUMERIC(6, 2),
	CONSTRAINT Produto_PK PRIMARY KEY ("Id")
);

CREATE TABLE "Usuarios"(
	"Id" UUID NOT NULL,
	"Nome" VARCHAR(100),
	"Login" Varchar(100),
	"Senha" VARCHAR(50),
	CONSTRAINT Usuario_PK PRIMARY KEY("Id")
);