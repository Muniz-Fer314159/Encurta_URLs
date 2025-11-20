📎 Encurtador de URL — C# + MongoDB + Docker

Um encurtador de URLs completo desenvolvido em C# (.NET 8) com MongoDB, utilizando arquitetura limpa e endpoints REST para criação, listagem, atualização, exclusão e redirecionamento de URLs encurtadas.
Inclui também um frontend simples e profissional, desenvolvido em HTML/CSS/JavaScript, para consumir a API.

🚀 Funcionalidades
Backend (API REST em .NET 8)

✔ Criar URL curta (POST /urls/encurtar)
✔ Buscar por URL encurtada (GET /urls/{shortenedURL})
✔ Listar todas as URLs (GET /urls)
✔ Atualizar URL original (PUT /urls/{shortenedURL})
✔ Remover URL (DELETE /urls/{shortenedURL})
✔ Redirecionar para URL original (GET /urls/r/{shortenedURL})

A API usa MongoDB como banco de dados e possui uma lógica de geração de strings aleatórias seguras para criação das URLs curtas.

🗃 Banco de Dados

O projeto utiliza MongoDB, podendo ser executado facilmente via Docker:

docker run -d -p 27017:27017 --name mongo encurtador-mongo mongo

🏗 Estrutura do Projeto
Backend/
 ├── Controllers/
 │     └── UrlsController.cs
 ├── Models/
 │     └── UrlModel.cs
 ├── Services/
 │     └── UrlsServices.cs
 ├── appsettings.json
 └── Program.cs

Frontend/
 ├── index.html
 ├── styles.css
 └── script.js

🧠 Tecnologias Utilizadas
Backend

.NET 8 Web API

C#

MongoDB Driver

Docker

Arquitetura em camadas

Frontend

HTML5

CSS3 (tema corporativo, design limpo)

JavaScript puro (fetch API)

🌐 Como Executar
1. Rodar o MongoDB
docker start encurtador-mongo

2. Rodar a API

No diretório Backend:

dotnet run


A API estará disponível em:

http://localhost:5125

3. Rodar o Frontend

Abra o arquivo:

Frontend/index.html

🖥 Demonstração do Frontend

O frontend permite:

Encurtar URLs

Visualizar todas as URLs encurtadas

Fazer o caminho inverso (em desenvolvimento ⚠)

E conta com design corporativo e interface profissional.

🔗 Exemplo de Uso
Criar URL curta

POST
http://localhost:5125/urls/encurtar

Body (raw / JSON string):

"https://exemplo.com"


Resposta:

{
  "originalURL": "https://exemplo.com",
  "shortenedURL": "y9WEfO"
}

Redirecionar
http://localhost:5125/urls/r/y9WEfO

📌 Futuras Expansões

Autenticação JWT

Expiração automática de URLs

Estatísticas de cliques

Painel administrativo completo

URL customizada pelo usuário

🧑‍💻 Autor

Murilo Ferreira Muniz
Estudante de Ciência da Computação & Desenvolvedor Backend em formação.
🇧🇷 Projeto acadêmico com foco em aprimorar lógica, APIs REST e integração com NoSQL