# Technology Stack

> **Purpose**
>
> This document describes the technologies used in the Library Management System, their roles within the project, and the reasons they were selected.

---

# Technology Overview

| Category | Technology | Version |
|----------|------------|---------|
| Framework | ASP.NET Core MVC | .NET 9 |
| Programming Language | C# | 13 |
| ORM | Entity Framework Core | .NET 9 Compatible |
| Database | MySQL | 8.x |
| Frontend | Razor Views | Built-in |
| Styling | Bootstrap | 5.x |
| Client-side Scripting | JavaScript | ES6 |
| Markup | HTML5 | Latest |
| Styling | CSS3 | Latest |
| IDE | Visual Studio Code | Latest |
| Version Control | Git | Latest |
| Repository Hosting | GitHub | Latest |

---

# Backend Technologies

## ASP.NET Core MVC (.NET 9)

### Purpose

ASP.NET Core MVC provides the application's architecture by separating the project into Models, Views, and Controllers.

### Why It Was Chosen

- Clean architecture
- Excellent performance
- Cross-platform
- Built-in Dependency Injection
- Strong community support
- Industry standard for enterprise applications

### Used For

- Routing
- Controllers
- Razor Views
- Authentication
- Model Binding
- Validation

---

## C#

### Purpose

Primary programming language used throughout the project.

### Why It Was Chosen

- Strong typing
- Object-Oriented
- Excellent support within ASP.NET Core
- Easy integration with Entity Framework Core

Used throughout:

- Models
- Controllers
- ViewModels
- Business Logic

---

## Entity Framework Core

### Purpose

Object Relational Mapper (ORM).

Allows interaction with the database using C# objects instead of SQL queries.

### Why It Was Chosen

- Code First development
- Automatic migrations
- LINQ support
- Strong typing
- Simplifies CRUD operations

### Used For

- CRUD
- Database Queries
- Relationships
- Migrations

---

# Database

## MySQL

### Purpose

Stores all application data.

### Tables

- Books
- Students
- Librarians
- Publications
- BorrowRecords
- Users

### Why MySQL

- Reliable
- Open Source
- Easy to integrate with EF Core
- Lightweight
- Widely used

---

# Frontend

## Razor Views

### Purpose

Render dynamic HTML.

### Advantages

- Server-side rendering
- Tight integration with MVC
- Strong typing
- Easy data binding

---

## Bootstrap 5

### Purpose

Responsive UI Framework.

### Used For

- Cards
- Tables
- Navigation
- Buttons
- Forms
- Responsive Layout

### Advantages

- Mobile friendly
- Fast development
- Consistent UI
- Prebuilt components

---

## HTML5

Provides the page structure.

Used in every View.

---

## CSS3

Responsible for

- Layout
- Colours
- Typography
- Spacing
- Responsive design

---

## JavaScript

Used for

- Client-side interactions
- Form behaviour
- UI enhancements

No JavaScript frameworks (React, Angular, Vue) are used because the project is based on ASP.NET Core MVC with Razor Views.

---

# Development Tools

## Visual Studio Code

Primary development environment.

Reasons

- Lightweight
- Cross-platform
- Excellent C# extension support
- Git integration

---

## Git

Used for

- Version Control
- Change Tracking
- Collaboration

---

## GitHub

Used for

- Source Code Hosting
- Documentation
- Portfolio Showcase

---

# Development Approach

The application follows

- MVC Architecture
- Entity Framework Code First
- Session-Based Authentication
- Server-Side Rendering
- Server-Side Validation

The project intentionally avoids unnecessary complexity by using the tools most appropriate for its scope.

---

# Package Highlights

Major NuGet packages include:

- Microsoft.AspNetCore.Mvc
- Microsoft.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

Additional packages may be installed as the project evolves.

---

# Compatibility

| Component | Version |
|-----------|---------|
| .NET SDK | 9.x |
| ASP.NET Core | 9.x |
| Entity Framework Core | 9.x |
| Bootstrap | 5.x |
| MySQL | 8.x |

---

# Future Technology Enhancements

Potential future additions include:

- ASP.NET Core Identity
- REST API
- JWT Authentication
- SignalR
- Docker
- Azure Deployment
- Unit Testing (xUnit)
- Swagger
- Redis Caching
- CI/CD using GitHub Actions

These technologies were intentionally not included in the current version to keep the project focused on demonstrating core ASP.NET Core MVC concepts.