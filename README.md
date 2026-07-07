# 💰 Monivo

Monivo is a personal finance management platform developed with **ASP.NET Core MVC** following **Clean Architecture** principles.

The project is designed to help users manage their personal finances by tracking income, expenses, recurring transactions and monthly budgets through a scalable and maintainable architecture.

---

## ✨ Features

- User Management
- Category Management
- Income & Expense Tracking
- Monthly Budget Planning
- Recurring Transactions
- Parameter Management
- SQL Server Database
- Clean Architecture
- Layered Architecture
- Entity Framework Core (Code First)
- Fluent API Configuration

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

- [x] Clean Architecture setup
- [x] Entity Framework Core integration
- [x] Database design
- [x] Fluent API configurations
- [ ] Repository Pattern
- [ ] Generic Repository
- [ ] Service Layer
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
