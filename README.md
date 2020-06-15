# Exemplo de API RESTful

Este é um exemplo simples de uma API RESTful, feito em C#. Para baixá-lo, instale o [Git](https://git-scm.com/) e execute o comando 

`git clone https://github.com/GabrielBueno/ExemploApiRest.git`

Ou baixe este repositório clicando em **Clone or download** > **Download ZIP**, aqui mesmo no GitHub.

## Compilando e executando

Para executar este projeto, você precisará instalar o [.NET Core SDK 3.1](https://dotnet.microsoft.com/download).

Para executar o projeto, você pode abri-lo no Visual Studio, pelo arquivo .sln na raiz do projeto; Pelo VSCode, com a extensão C#; ou por linha de comando, abrindo um terminal na raiz do projeto, e executando o comando `dotnet run`. 

Ao executar, atente-se à porta onde o serviço estará rodando. Você pode vê-la nas mensagens de log exibidas após a execução. Normalmente, esta porta é padrão, 5000. 

## Recursos e endpoints

Para exemplificar um controlador simples, utilizamos dois recursos, livros e autores, onde um livro pode possuir um autor.

Para executar as rotas documentadas aqui, você pode utilizar o [Postman](https://www.postman.com/).

Quando for executar uma das rotas, lembre-se de antes preceder o endpoint por:
`http://localhost:{porta}`

Por exemplo, assumindo que a porta seja a padrão 5000, para executar o endpoint de obter livros, a URL será 
`http://localhost:5000/api/v1/livros`

Nas rotas que apresentam algo como _{id}_, este pedaço da Uri é uma variável, podendo ser substituída por um valor qualquer, sem as chaves. Por exemplo, na rota `api/v1/livros/{id}`, para executá-la, você pode escrever `api/v1/livros/1`, `api/v1/livros/2`, `api/v1/livros/3`, etc.

## Rotas

 - GET /api/v1/livros **Obtém todos os livros**

 - GET /api/v1/livros/{id} **Obtém um livro por id**

 - POST /api/v1/livros **Cria um livro**
    No corpo da requisição você deverá descrever, em JSON, o livro que será criado, no seguinte modelo:
    ````
        {
            "titulo": "string",
            "autor": {
                "nome": "string",
                "pais": "string"
            }
        }
    ````

 - PUT /api/v1/livros/{id} **Edita um livro especificado pelo seu id**
    No corpo da requisição você deverá descrever, em JSON, todos os dados do livro que será editado, no seguinte modelo:
        ````
            {
                "titulo": "string",
                "autor": {
                    "nome": "string",
                    "pais": "string"
                }
            }
        ````

 - DELETE /api/v1/livros/{id} **Obtém um livro por id**

