# UserManagement

A user management system built in C#, evolving from a Console application to a REST API — focused on architectural best practices, Clean Code, and incremental learning.

## 📌 About the Project

This repository contains **two projects** that share the same domain, representing the natural evolution of a backend system:

| Project | Description | Status |
|---|---|---|
| `UserManagementConsole` | Console CRUD with JSON persistence | ✅ v4.0 Complete |
| `UserManagementAPI` | REST API with ASP.NET Core | ✅ v5.0 Complete |

Developed as a learning project for career transition to Backend Development, simulating a real backend scenario with focus on **decoupled architecture**, **clean code**, and **incremental evolution**.

---

## 🗂️ Repository Structure

```
UserManagement/
│
├── [Console Project - v1 to v4]         ← Root of the repo
│   ├── Entities/User.cs
│   ├── Interfaces/IUserRepository.cs
│   ├── Repositories/UserJsonRepository.cs
│   ├── Services/UserService.cs
│   ├── Validations/Validations.cs
│   ├── Utils/ConsoleMenu.cs
│   ├── Program.cs
│   └── UserManagement.Tests/            ← 13 unit tests
│
└── UserManagementAPI/                   ← REST API v5.0
    ├── Controllers/UsersController.cs
    ├── DTOs/
    │   ├── CreateUserDto.cs
    │   └── UpdateUserDto.cs
    ├── Entities/User.cs
    ├── Interfaces/IUserRepository.cs
    ├── Repositories/UserJsonRepository.cs
    ├── Services/UserService.cs
    ├── Validations/Validations.cs
    ├── Data/users.json
    └── Program.cs
```

---

## 🖥️ Project 1 — UserManagementConsole (v4.0)

Console-based user management with full CRUD, validations, and JSON persistence.

### ⚙️ Features

- ✅ User registration with strict validation (Name, Age, Email)
- ✅ List, edit, and delete users
- ✅ Partial name search (case-insensitive)
- ✅ JSON persistence (auto-save and auto-load)
- ✅ Colored messages (green=success, red=error, yellow=warning)
- ✅ Confirmation prompt before deletion
- ✅ 13 unit tests with xUnit

### 🧱 Architecture

- **Repository Pattern** — persistence isolated from business logic
- **Dependency Injection** — decoupled dependencies
- **SOLID Principles** — SRP, DIP, ISP applied throughout
- **Layer Separation** — Entities, Interfaces, Repositories, Services, Utils

### ▶️ How to Run

```bash
git clone https://github.com/Andre1Freitas/UserManagement.git
cd UserManagement
dotnet run
```

---

## 🌐 Project 2 — UserManagementAPI (v5.0)

REST API built with ASP.NET Core, exposing the same domain via HTTP endpoints.

### ⚙️ Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/api/users` | List all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users` | Create new user |
| PUT | `/api/users/{id}` | Update user |
| DELETE | `/api/users/{id}` | Delete user |

### 🧱 Architecture

- **ASP.NET Core Web API (.NET 8)**
- **DTOs** — separates API input from domain model
- **Swagger** — interactive API documentation
- **JSON persistence** — same pattern as Console (temporary, before database)
- **Reused validations** — same `Validations.cs` from Console project

### ▶️ How to Run

```bash
cd UserManagementAPI
dotnet run
```

Then open in browser: `http://localhost:5166/swagger`

---

## 🚀 Project Evolution

### ✅ v1.0 — Foundation
Basic in-memory CRUD with organized folder structure and Regex validations.

### ✅ v2.0 — CSV Persistence
Repository Pattern, Dependency Injection, and CSV file persistence.

### ✅ v3.0 — JSON + GUID
Migration to JSON, GUID as unique identifier, and complete UI refactoring.

### ✅ v4.0 — UX + Tests + English
Partial search, colored messages, 13 unit tests with xUnit, full codebase in English.

### ✅ v5.0 — REST API
ASP.NET Core Web API with 5 endpoints, DTOs, Swagger, and JSON persistence.

### 🔜 v6.0 — Entity Framework Core + SQLite *(next)*
Replace JSON with a real database using EF Core migrations and SQLite.

---

## 🛠️ Technologies Used

- **C# (.NET 8)**
- **ASP.NET Core Web API**
- **System.Text.Json**
- **xUnit** — unit testing
- **Swagger / Swashbuckle**
- **LINQ**
- **GUID** — unique identifiers
- **Repository Pattern + Dependency Injection**

---

## 🎓 About the Developer

Project developed by **André Freitas** as part of a learning journey for career transition to Backend Developer.

**Goal:** Build a solid portfolio demonstrating technical evolution, clean architecture, and real-world backend patterns.

**Target:** Backend internship by June 2026.

---

## 📝 License

This project is under MIT License. Feel free to use it as a study reference!