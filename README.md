# 💰 Monivo

Monivo is a personal finance management platform developed with **ASP.NET Core MVC** following **Clean Architecture** principles.

The project is designed to help users manage their personal finances by tracking income, expenses, recurring transactions and monthly budgets through a scalable and maintainable architecture.

---

## ✨ Features
- Clean Architecture
- Repository Pattern
- Generic Repository
- Dependency Injection
- CQRS (Command Query Responsibility Segregation)
- MediatR
- FluentValidation
- ASP.NET Core MVC
- Entity Framework Core (Code First)
- SQL Server
- 
---

## 🏗️ Architecture

The solution follows a layered architecture inspired by Clean Architecture.

```text
Monivo
│
├── Monivo.Application
├── Monivo.Domain
├── Monivo.Infrastructure
├── Monivo.Persistence
└── Monivo.Web
```

### Layer Responsibilities

| Layer | Responsibility |
|--------|----------------|
| **Monivo.Domain** | Entities and core business models |
| **Monivo.Application** | Business rules, services, DTOs and interfaces |
| **Monivo.Persistence** | Entity Framework Core, DbContext, repositories and configurations |
| **Monivo.Infrastructure** | External services and infrastructure implementations |
| **Monivo.Web** | ASP.NET Core MVC presentation layer |

---

## 🛠️ Technologies

- ASP.NET Core MVC
- C#
- .NET 8
- Entity Framework Core
- SQL Server
- Fluent API
- LINQ
- Dependency Injection
- Clean Architecture
- Code First

---

## 📂 Project Structure

```text
Monivo
│
├── Monivo.Application
├── Monivo.Domain
├── Monivo.Infrastructure
├── Monivo.Persistence
└── Monivo.Web
```

---

## 🚀 Roadmap

## 🚀 Roadmap

- [x] Clean Architecture setup
- [x] Entity Framework Core integration
- [x] Database design
- [x] Fluent API configurations
- [x] Repository Pattern
- [x] Generic Repository
- [x] Service Layer
- [x] Category CRUD operations
- [x] CQRS structure
- [x] MediatR integration
- [x] FluentValidation integration
- [ ] AutoMapper integration
- [ ] Complete CQRS for queries and commands
- [ ] Global Exception Handling
- [ ] Result Pattern
- [ ] Authentication & Authorization
- [ ] Dashboard
- [ ] Reports & Analytics
- [ ] Charts
- [ ] Export to Excel / PDF
- [ ] Responsive UI

---

## 👨‍💻 Author

**Deniz Sert**

Software Engineer

---

⭐ Feel free to follow the project's progress.
