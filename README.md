# UserManagementConsole

Uma aplicação console em C# para gerenciamento de usuários, focada em boas práticas de arquitetura, Clean Code e persistência de dados.

## 📌 Sobre o Projeto

Este projeto é um sistema de gerenciamento de usuários que permite operações completas de CRUD (Criar, Ler, Atualizar, Remover). 

Ele foi desenvolvido como um projeto de estudo para transição de carreira, simulando um cenário real de backend com foco em **arquitetura desacoplada** e **regras de negócio isoladas**.

### Diferenciais Técnicos (Arquitetura)
O projeto evoluiu de um código simples para uma arquitetura robusta aplicando conceitos de Engenharia de Software:
* **Repository Pattern:** A lógica de persistência (arquivos) está totalmente isolada das regras de negócio.
* **Injeção de Dependência (DI):** O sistema utiliza inversão de controle para gerenciar dependências.
* **SOLID:** Aplicação de princípios como Single Responsibility e Dependency Inversion.
* **Defensive Programming:** O carregamento de dados é protegido contra arquivos corrompidos ou mal formatados.

---

## ⚙️ Funcionalidades

* **Cadastro:** Criação de novos usuários com validação rigorosa (Idade, E-mail, Nome).
* **Listagem:** Exibição de todos os usuários cadastrados.
* **Persistência de Dados:** Salvamento automático em arquivo CSV (`users.csv`).
* **Recuperação de Dados:** Carregamento automático ao iniciar o sistema.
* **Busca:** Localização de usuários por nome.
* **Remoção:** Exclusão de usuários do sistema e do arquivo.

---

## 🧱 Estrutura do Projeto

A solução segue uma organização em camadas lógicas:

```text
UserManagementConsole/ 
├── Entities/ # Modelos de domínio (Ex: Pessoa.cs) 
├── Interfaces/ # Contratos para garantir desacoplamento (Ex: IUserRepository.cs) 
├── Repositories/ # Implementação da persistência (Ex: UserCsvRepository.cs) 
├── Services/ # Regras de negócio (Ex: GerenciadorPessoas.cs) 
├── Utils/ # Validadores e ferramentas estáticas 
├── Data/ # Pasta onde o arquivo users.csv é armazenado 
└── Program.cs # Ponto de entrada e Injeção de Dependência
```

---

## 🚀 Histórico de Versões

### ✅ Versão 1 (Concluída)
* CRUD em memória.
* Estrutura básica de pastas.
* Validações com Regex.

### ✅ Versão 2 (Concluída - Atual)
* Implementação do **Repository Pattern**.
* Persistência em arquivo **CSV**.
* Carregamento seguro de dados (`Load` com validação).
* Aplicação de **Injeção de Dependência**.

### 🔜 Versão 3 (Planejada)
* Edição de usuários já cadastrados.
* Tratamento de exceções (Try/Catch) global.
* Logs de erro.

---

## 🛠️ Tecnologias Utilizadas

* C# (.NET 8)
* System.IO (Manipulação de arquivos)
* LINQ (Consultas em coleções)

---

## ▶️ Como Rodar

1.  Clone o repositório:
    ```bash
    git clone https://github.com/Andre1Freitas/UserManagementConsole.git
    ```
2.  Navegue até a pasta do projeto:
    ```bash
    cd UserManagementConsole
    ```
3.  Restaure as dependências e execute:
    ```bash
    dotnet run
    ```
4.  O arquivo de banco de dados (`users.csv`) será criado automaticamente na pasta `Data` após o primeiro cadastro.