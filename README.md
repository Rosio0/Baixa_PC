## 📌 Baixa_PC - Gestão de Processos de Equipamentos Escolares
 🖥️ Descrição
O Baixa_PC é uma aplicação desenvolvida em C# com Windows Forms, MySQL e integração com Excel. Permite gerir a entrega, atualização e baixa de equipamentos escolares de forma eficiente.

## 🚀 Funcionalidades
✔️ Pesquisa de alunos e encarregados de educação pelo NIF
 
✔️ Gestão de dados de computadores (tipo, número de série, estado, etc.)

✔️ Geração de PDFs com os detalhes do processo

✔️ Sincronização automática com a base de dados MySQL

✔️ Atualização e consulta de dados diretamente num ficheiro Excel

✔️ Interface intuitiva com Windows Forms

## 🛠️ Tecnologias Utilizadas
📌 Linguagem: C#

📌 Base de Dados: MySQL

📌 Bibliotecas:

iTextSharp - Geração de PDFs

EPPlus - Manipulação de Excel

ClosedXML - Manipulação de Excel

📌 Ambiente de Desenvolvimento: Visual Studio

## 📦 Instalação e Configuração

1️⃣ Pré-requisitos

🔹 Instalar o .NET Framework 4.7.2+

🔹 Instalar MySQL Server e criar a base de dados (computadores_db)

🔹 Configurar a string de conexão no DatabaseHelper.cs:

csharp
Copiar
Editar
private static readonly string connectionString = 
    "Server=localhost;Database=computadores_db;User Id=root;Password=mysql;";
				
🔹 Instalar as dependências no NuGet Package Manager:

mathematica
Copiar
Editar

Install-Package MySql.Data

Install-Package iTextSharp

Install-Package EPPlus

Install-Package ClosedXML


▶️ Como Executar

1️⃣ Abrir o projeto no Visual Studio

2️⃣ Configurar a base de dados e ficheiros necessários

3️⃣ Executar a aplicação (F5)

## 📄 Licença

Este projeto **não possui uma licença pública**. O uso e modificação do código requer permissão do autor.



## 📞 Contacto

Se tiveres dúvidas ou sugestões, entra em contacto:

✉️ Email: davidambrosio04@gmail.com

📌 GitHub: github.com/Rosio0
