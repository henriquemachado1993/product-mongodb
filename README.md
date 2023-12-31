# MongoDB .NET Core Demo
Este é um projeto de demonstração simples para interação com o MongoDB usando .NET Core 6. Ele inclui uma aplicação WebApi RESTful básica com Swagger para realizar operações CRUD em coleções de produtos e categorias.

## Recursos
MongoDB Driver: Utiliza o driver oficial do MongoDB para .NET (MongoDB.Driver) para se conectar ao banco de dados MongoDB.

## Estrutura do Projeto
* MongoDBContext: Configura a conexão com o MongoDB e fornece acesso às coleções.
* Categoria e Produto: Classes de modelo para representar dados no MongoDB.
* ProdutoService: Serviço para operações CRUD em produtos.
* Program: Um exemplo simples de como usar o MongoDBContext e o ProdutoService.

## Pré-requisitos
.NET Core 6 SDK
Docker e Docker-Compose

## Como Usar
* Clone o repositório.
* Execute o MongoDB e o Adminer usando o Docker-Compose:
* Crie um arquivo docker-compose.yml em alguma pasta e preencha com as informações abaixo:
```
version: '3'

services:

  mongodb:
    image: mongo:5
    environment:
      - MONGO_INITDB_ROOT_USERNAME=user
      - MONGO_INITDB_ROOT_PASSWORD=password
      - MONGO_INITDB_DATABASE=mongodemo
    container_name: mongodb
    volumes:
      - dbdata:/data/db
    ports:
      - "27017:27017"

  adminer:
    image: dehy/adminer
    container_name: adminer
    depends_on:
      - mongodb
    ports:
      - "8081:8081"

volumes:
  dbdata:
```
* bash
```
docker-compose up -d
```

Execute o projeto.
