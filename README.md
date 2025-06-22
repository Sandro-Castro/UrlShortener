# UrlShortener - Encurtador de URLs

Este projeto implementa um encurtador de URLs simples utilizando .NET 9 Minimal API e SQLite. O sistema gera chaves curtas usando Base62 e inclui um frontend básico para teste.

## 📑 Sumário

- [Tecnologias Utilizadas](#-tecnologias-utilizadas)

- [Estrutura do Projeto](#-estrutura-do-projeto)

- [Pré-requisitos](#-pré-requisitos)

- [Como Rodar Localmente](#-como-rodar-localmente)

- [Exemplos de Uso](#-exemplos-de-uso)


---

## 🛠️ Tecnologias Utilizadas

- **Backend**: C# (.NET 9 Minimal API)

- **Banco de Dados**: SQLite

- **ORM**: Entity Framework Core

- **Frontend**: HTML, CSS, JavaScript

- **SDK**: .NET 9 SDK

- **Versionamento**: Git / GitHub

---

## 📂 Estrutura do Projeto

```

UrlShortener/

├─ UrlShortener.csproj

├─ Program.cs

├─ Models/

│   └─ UrlMapping.cs

├─ Data/

│   └─ AppDbContext.cs

├─ Migrations/

├─ Services/

│   └─ UrlService.cs

├─ Utils/

│   └─ Base62Converter.cs

├─ wwwroot/

│   └─ index.html

└─ urlshortener.db

```

- **Program.cs**: Ponto de entrada que configura os endpoints da API

- **Models/**: Entidades do banco de dados (EF Core)

- **Data/**: Contexto do banco de dados (DbContext)

- **Services/**: Lógica de negócio da aplicação

- **Utils/**: Classes utilitárias (conversor Base62)

- **wwwroot/**: Arquivos estáticos para o frontend

---

## ⚙️ Pré-requisitos

Antes de começar:

Verifique a instalação do .NET:

```bash

dotnet --version

```

---

## 🚀 Como Rodar Localmente

### 1. Clonar o repositório

```bash

git clone https://github.com/Sandro-Castro/UrlShortener.git

cd UrlShortener

```

### 2. Restaurar dependências

```bash

dotnet restore

```

### 3. Aplicar migrações do banco de dados

```bash

dotnet ef database update

```

> **Nota**: O projeto já aplica migrações automaticamente ao iniciar

### 4. Executar a aplicação

```bash

dotnet run

```

### 5. Acessar a aplicação

Abra no navegador:

[http://localhost:5262](http://localhost:5262)

---

## 📝 Exemplos de Uso

### 1. Usando o Frontend

1. Acesse [http://localhost:5262](http://localhost:5262)

2. Insira sua URL longa no campo

3. Clique em "Encurtar"

4. O link curto será gerado e exibido

### 2. Usando a API com curl

**Encurtar URL:**

```bash

curl -X POST http://localhost:5262/shorten \

-H "Content-Type: application/json" \

-d "{\"OriginalUrl\":\"https://www.google.com\"}"

```

**Resposta:**

```json

{

"key": "b",

"shortUrl": "http://localhost:5262/b"

}

```

**Redirecionamento:**

Acesse o link curto no navegador para ser redirecionado à URL original:

```

http://localhost:5262/b

```
