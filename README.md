# UserManagementConsole

A simple console application built in C# for managing users, focused on practicing clean code, input validation, and basic application structure.

## 📌 About the Project

This project is a **console-based user management system** that allows basic CRUD operations.
It was created as a learning project with the goal of becoming a **portfolio-ready backend application** using .NET.

The application emphasizes:
- Clear separation of responsibilities
- Input validation
- Readable and maintainable code

---

## ⚙️ Features

- Create a new user with validation
- List all registered users
- Search for a user by name
- Remove a user from the system

## Version 2 – File Persistence

The application now supports:
- Saving users to a CSV file
- Loading users automatically on startup
- Data persistence between executions

---

## 🧱 Project Structure

```text
UserManagementConsole/
├── Entities/
│   └── Pessoa.cs
├── Services/
│   └── GerenciadorPessoas.cs
├── Utils/
│   └── Validacoes.cs
├── Program.cs
├── UserManagement.csproj
└── Repositories/
	└── UserCsvRepositorie.cs
```

**Entities**  
Contains the domain models used by the application. 

**Services**  
Responsible for business logic and data manipulation.

**Utils**  
Contains validation logic shared across the application.

---

## 🛠️ Technologies Used

- C#
- .NET (Console Application)

---

## ▶️ How to Run
```bash
1. Clone the repository:
git clone https://github.com/Andre1Freitas/UserManagementConsole.git
2. Navigate to the project folder:
cd UserManagementConsole
3. Restore dependencies:
dotnet restore
4. Run the application:
dotnet run
```
