# UserManagementConsole

Uma aplicação console em C# para gerenciamento de usuários, focada em boas práticas de arquitetura, Clean Code e persistência de dados.

## 📌 Sobre o Projeto

Este projeto é um **sistema de gerenciamento de usuários** que permite operações completas de CRUD (Criar, Ler, Atualizar, Remover). 

Desenvolvido como projeto de estudo para transição de carreira, simula um cenário real de backend com foco em **arquitetura desacoplada**, **código limpo** e **evolução incremental**.

### 🎯 Diferenciais Técnicos

O projeto evoluiu de um código simples para uma arquitetura robusta, aplicando conceitos fundamentais de Engenharia de Software:

* **Repository Pattern:** Lógica de persistência totalmente isolada das regras de negócio
* **Dependency Injection (DI):** Inversão de controle para gerenciar dependências
* **SOLID Principles:** Single Responsibility, Dependency Inversion, Interface Segregation
* **GUID como identificador:** IDs únicos e distribuídos, preparando para ambientes multi-usuário
* **JSON Serialization:** Migração de CSV para JSON com `System.Text.Json`
* **Separação de Camadas:** UI (MenuConsole), Serviços (GerenciadorPessoas), Dados (Repository)

---

## ⚙️ Funcionalidades

* ✅ **Cadastro:** Criação de usuários com validação rigorosa (Nome, Idade, Email)
* ✅ **Listagem:** Exibição numerada de todos os usuários
* ✅ **Edição:** Atualização de dados de usuários existentes
* ✅ **Remoção:** Exclusão por seleção numerada
* ✅ **Busca:** Localização de usuários na lista
* ✅ **Persistência JSON:** Salvamento automático em `users.json`
* ✅ **Recuperação Automática:** Carregamento seguro ao iniciar o sistema
* ✅ **Interface Limpa:** Menu interativo com validações em tempo real

---

## 🧱 Estrutura do Projeto

Organização em camadas lógicas seguindo padrões de arquitetura:

```
UserManagementConsole/
├── Entities/           # Modelos de domínio (Pessoa.cs)
├── Interfaces/         # Contratos (IUserRepository.cs)
├── Repositories/       # Persistência de dados
│   ├── UserJsonRepository.cs    # Implementação atual (JSON)
│   └── UserCsvRepository.cs     # Legado (mantido para referência)
├── Services/           # Regras de negócio (GerenciadorPessoas.cs)
├── Utils/              # Validadores e UI
│   ├── Validacoes.cs
│   └── MenuConsole.cs  # Camada de apresentação
├── Data/               # Arquivos de dados (users.json)
└── Program.cs          # Ponto de entrada
```

---

## 🚀 Evolução do Projeto

### ✅ Versão 1.0 - Fundação (Concluída)
* CRUD básico em memória
* Estrutura de pastas organizada
* Validações com Regex

### ✅ Versão 2.0 - Persistência CSV (Concluída)
* Implementação do Repository Pattern
* Persistência em arquivo CSV
* Injeção de Dependência
* Carregamento seguro com validação

### ✅ Versão 3.0 - Migração JSON + GUID (Atual)
* **GUID** como identificador único (preparação para sistemas distribuídos)
* Migração de **CSV para JSON** (serialização nativa)
* **Funcionalidade de edição** implementada
* **Refatoração completa da UI** (classe MenuConsole)
* Redução de ~150 para ~45 linhas no Program.cs
* Eliminação de código duplicado

### 🔜 Versão 4.0 - Melhorias de UX (Planejada)
* Busca por parte do nome (filtro parcial)
* Mensagens coloridas (sucesso/erro)
* Confirmação antes de remover
* Tratamento robusto de exceções
* Paginação para listas grandes

### 🌐 Versão 5.0 - Migração para API REST (Próximo Projeto)
* Conversão para ASP.NET Core Web API
* Banco de dados com Entity Framework Core
* Endpoints REST (GET, POST, PUT, DELETE)
* Autenticação JWT
* Documentação com Swagger
* Deploy em nuvem

---

## 🛠️ Tecnologias Utilizadas

* **C# (.NET 8)**
* **System.Text.Json** - Serialização/Deserialização
* **LINQ** - Consultas em coleções
* **Guid** - Identificadores únicos
* **Repository Pattern** - Arquitetura
* **Dependency Injection** - Desacoplamento

---

## ▶️ Como Executar

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/Andre1Freitas/UserManagementConsole.git
   ```

2. **Navegue até a pasta:**
   ```bash
   cd UserManagementConsole
   ```

3. **Restaure e execute:**
   ```bash
   dotnet restore
   dotnet run
   ```

4. **Resultado:**
   * O arquivo `users.json` será criado automaticamente em `Data/`
   * Interface interativa aparecerá no console

---

## 📚 Aprendizados e Conceitos Aplicados

Durante o desenvolvimento deste projeto, foram aplicados:

* **Clean Code:** Métodos pequenos, nomes descritivos, responsabilidade única
* **Refatoração:** Código evoluído iterativamente (CSV → JSON, Program gigante → MenuConsole)
* **Versionamento:** Commits semânticos seguindo Conventional Commits
* **Arquitetura em Camadas:** Separação clara entre UI, Serviços e Dados
* **Princípios SOLID:** Aplicados em Interfaces, Repository e Services
* **Boas Práticas Git:** Commits atômicos, mensagens descritivas, histórico limpo

---

## 🎓 Sobre o Desenvolvedor

Projeto desenvolvido por **André Freitas** como parte do aprendizado para transição de carreira para Desenvolvedor Backend.

**Objetivo:** Construir um portfólio sólido demonstrando evolução técnica, capacidade de refatoração e aplicação de padrões de mercado.

---

## 📝 Licença

Este projeto está sob licença MIT. Sinta-se livre para usar como referência de estudos!