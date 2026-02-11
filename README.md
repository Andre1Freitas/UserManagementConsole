# UserManagementConsole

A console-based user management application in C#, focused on architectural best practices, Clean Code, and data persistence.

## 📌 About the Project

This project is a **user management system** that provides full CRUD operations (Create, Read, Update, Delete).

Developed as a learning project for career transition to Backend Development, it simulates a real backend scenario with focus on **decoupled architecture**, **clean code**, and **incremental evolution**.

### 🎯 Technical Highlights

The project evolved from simple code to robust architecture, applying fundamental Software Engineering concepts:

* **Repository Pattern:** Data persistence logic completely isolated from business rules
* **Dependency Injection (DI):** Inversion of control for dependency management
* **SOLID Principles:** Single Responsibility, Dependency Inversion, Interface Segregation
* **GUID as identifier:** Unique and distributed IDs, preparing for multi-user environments
* **JSON Serialization:** Migration from CSV to JSON using `System.Text.Json`
* **Layer Separation:** UI (MenuConsole), Services (PersonService), Data (Repository)
* **English Codebase:** Professional naming conventions following industry standards

---

## ⚙️ Features

* ✅ **User Registration:** Create users with strict validation (Name, Age, Email)
* ✅ **Listing:** Numbered display of all users
* ✅ **Editing:** Update existing user data
* ✅ **Deletion:** Remove users with confirmation prompt
* ✅ **Search:** Find users by partial name match (case-insensitive)
* ✅ **JSON Persistence:** Automatic saving to `users.json`
* ✅ **Auto-Recovery:** Safe data loading on system startup
* ✅ **Clean Interface:** Interactive menu with real-time validation
* ✅ **Colored Messages:** Visual feedback (green=success, red=error, yellow=warning)
* ✅ **Empty List Handling:** Prevents operations on empty data with user-friendly messages

---

## 🧱 Project Structure

Organized in logical layers following architectural patterns:
```
UserManagementConsole/
├── Entities/           # Domain models (User.cs)
├── Interfaces/         # Contracts (IUserRepository.cs)
├── Repositories/       # Data persistence
│   ├── UserJsonRepository.cs    # Current implementation (JSON)
│   └── UserCsvRepository.cs     # Legacy (kept for reference)
├── Services/           # Business logic (PersonService.cs)
├── Utils/              # Validators and UI
│   ├── Validations.cs
│   └── MenuConsole.cs  # Presentation layer
├── Data/               # Data files (users.json)
└── Program.cs          # Entry point
```

---

## 🚀 Project Evolution

### ✅ Version 1.0 - Foundation (Completed)
* Basic in-memory CRUD
* Organized folder structure
* Regex validations

### ✅ Version 2.0 - CSV Persistence (Completed)
* Repository Pattern implementation
* CSV file persistence
* Dependency Injection
* Safe loading with validation

### ✅ Version 3.0 - JSON Migration + GUID (Completed)
* **GUID** as unique identifier (preparation for distributed systems)
* Migration from **CSV to JSON** (native serialization)
* **Edit functionality** implemented
* **Complete UI refactoring** (MenuConsole class)
* Reduction from ~150 to ~45 lines in Program.cs
* Eliminated code duplication

### ✅ Version 4.0 - UX Improvements + English Translation (Current)
* **Partial name search** with case-insensitive filtering
* **Colored console messages** (success/error/warning)
* **Confirmation prompts** before deletion
* **Robust exception handling** and GUID validation
* **Empty list validation** before operations
* **Complete codebase translation to English**
* Professional naming conventions (PersonService, User, Validations)

### 🔜 Version 5.0 - Unit Tests (Planned)
* xUnit test setup
* Validation method tests
* Service layer tests with mocking
* Test coverage report

### 🌐 Version 6.0 - REST API Migration (Next Project)
* Conversion to ASP.NET Core Web API
* Database with Entity Framework Core + SQLite
* REST endpoints (GET, POST, PUT, DELETE)
* JWT Authentication
* Swagger documentation
* Cloud deployment

---

## 🛠️ Technologies Used

* **C# (.NET 8)**
* **System.Text.Json** - Serialization/Deserialization
* **LINQ** - Collection queries
* **Guid** - Unique identifiers
* **Repository Pattern** - Architecture
* **Dependency Injection** - Decoupling
* * **xUnit** - Unit testing framework

---

## ▶️ How to Run

1. **Clone the repository:**
```bash
   git clone https://github.com/Andre1Freitas/UserManagementConsole.git
```

2. **Navigate to folder:**
```bash
   cd UserManagementConsole
```

3. **Restore and run:**
```bash
   dotnet restore
   dotnet run
```

4. **Result:**
   * `users.json` file will be automatically created in `Data/`
   * Interactive interface will appear in console

---

## 📚 Learnings and Applied Concepts

During the development of this project, the following were applied:

* **Clean Code:** Small methods, descriptive names, single responsibility
* **Refactoring:** Code evolved iteratively (CSV → JSON, large Program → MenuConsole)
* **Version Control:** Semantic commits following Conventional Commits
* **Layered Architecture:** Clear separation between UI, Services, and Data
* **SOLID Principles:** Applied in Interfaces, Repository, and Services
* **Git Best Practices:** Atomic commits, descriptive messages, clean history
* **English Codebase:** Professional naming for portfolio and international standards]
* **Unit Testing:** Automated testing with xUnit, AAA pattern, Theory/Fact attributes

---

## 🎓 About the Developer

Project developed by **André Freitas** as part of learning journey for career transition to Backend Developer.

**Goal:** Build a solid portfolio demonstrating technical evolution, refactoring skills, and application of industry patterns.

**Learning Timeline:**
- v1.0: Console basics and CRUD operations
- v2.0: Architecture patterns (Repository, DI)
- v3.0: Data migration and UI refactoring
- v4.0: UX polish and professional code standards
- v5.0+: Testing and API development (in progress)

---

## 📝 License

This project is under MIT License. Feel free to use it as study reference!