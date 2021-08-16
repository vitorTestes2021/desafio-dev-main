<h1 align="center">
  <a href="#"> CNAB API </a>
</h1>

<h3 align="center">
    A api feita para integrar CNAB.
</h3>

<h4 align="center">
  Concluído
</h4>

# Tabela de conteúdos

<!--ts-->

-   [Sobre o projeto](#-sobre-o-projeto)
-   [Funcionalidades](#-funcionalidades)
-   [Layout](#-layout)
-   [Como executar o projeto](#-como-executar-o-projeto)
    -   [Pré-requisitos](#pré-requisitos)
    -   [Rodando a api (Backend)](#user-content--rodando-o-backend-servidor)
    -   [Rodando a aplicação web (Frontend)](#user-content--rodando-a-aplicação-web-frontend)
-   [Tecnologias](#-tecnologias)
    -   [Api](#user-content-server--.NETCore----c#)
    -   [Web](#user-content-website--angular----typescript)
-   [Autor](#-autor)
-   [Licença](#user-content--licença)
<!--te-->

## 💻 Sobre o projeto

CNAB API - é a api feita para integrar CNAB.

---

## ⚙️ Funcionalidades

-   [x] Empresas ou entidades podem fazer integrações de CNAB na plataforma web enviando:

    -   [x] um arquivo de texto

---

## 🎨 Layout

### Web

<p align="center" style="display: flex; align-items: flex-start; justify-content: center;">
  <img src="./apps/web/src/assets/home.png" width="400px">
</p>

---

## 🚀 Como executar o projeto

Este projeto é divido em três partes:

1. Backend (pasta api)
2. Frontend (pasta web)
3. Testes (pasta tests)

💡Tanto o Frontend quanto os Testes precisam que o Backend esteja sendo executado para funcionar.

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [Node.js](https://nodejs.org/en/), [.NET Core](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.412-windows-x64-installer).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

#### 🎲 Rodando a api (Backend)

```bash

# Clone este repositório
$ git clone https://github.com/vitorTestes2021/desafio-dev-main.git

# Acesse a pasta do projeto no terminal/cmd
$ cd desafio-dev-main

# Vá para a pasta api
$ cd apps/api

# Instale as dependências
$ dotnet build

# Execute a aplicação
$ dotnet run

# O servidor inciará na porta:5000 - acesse http://localhost:5000

```

#### 🧭 Rodando a aplicação web (Frontend)

```bash

# Clone este repositório
$ git clone https://github.com/vitorTestes2021/desafio-dev-main.git

# Acesse a pasta do projeto no terminal/cmd
$ cd desafio-dev-main

# Vá para a pasta web
$ cd apps/web

# Instale as dependências
$ npm install

# Execute a aplicação
$ npm run start

# O servidor inciará na porta:4200 - acesse http://localhost:4200

```

---

## 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

#### **Web** ([Angular](https://angular.io/) + [TypeScript](https://www.typescriptlang.org/))

-   **[Prime NG](https://primefaces.org/)**

> Veja o arquivo [package.json](https://github.com/vitorTestes2021/desafio-dev-main/blob/main/apps/web/package.json)

#### **Api** ([.NET Core](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-3.1.412-windows-x64-installer) + [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/))

-   **[Swagger (Para conferir os endpoints)](http://localhost:5000/swagger)**

#### **Banco de Dados** ([MySQL](https://www.mysql.com/))

-   **Rodar os scripts 001 e 002 (apps/api/scripts)**

---

## 🦸 Autor

<a href="https://www.linkedin.com/in/vitor-pires-azzone-85648b127/">
 <img style="border-radius: 50%;" src="https://media-exp1.licdn.com/dms/image/C4E03AQHx_d8IxbK48Q/profile-displayphoto-shrink_400_400/0/1625068176028?e=1634774400&v=beta&t=fthRpd46_IiF2uiFkLXOUNKiCfscXal5jvkVFqKFbCk" width="100px;" alt=""/>
 <br />
 <sub><b>Vitor Pires Azzone</b></sub></a>
 <br />

[![Linkedin Badge](https://img.shields.io/badge/-Vitor-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/vitor-pires-azzone-85648b127/)](https://www.linkedin.com/in/vitor-pires-azzone-85648b127/)

---

## 📝 Licença

Este projeto esta sobe a licença [MIT](./LICENSE).

Feito com ❤️ por Vitor Pires Azzone 👋🏽 [Entre em contato!](https://www.linkedin.com/in/vitor-pires-azzone-85648b127/)

---
