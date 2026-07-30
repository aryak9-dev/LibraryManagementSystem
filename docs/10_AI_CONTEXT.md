# AI Context

> **Purpose**
>
> This document provides the complete technical context of the project so that future AI assistants or developers can understand the project architecture, conventions, and design decisions before suggesting modifications.
>
> Always read this file before making architectural changes.

---

# Project Information

| Item | Value |
|------|-------|
| Project Name | Library Management System |
| Framework | ASP.NET Core MVC (.NET 9) |
| Language | C# |
| Architecture | MVC |
| ORM | Entity Framework Core |
| Database | MySQL |
| Frontend | Razor Views |
| Styling | Bootstrap 5 |
| Authentication | Session Based |
| IDE | Visual Studio Code |
| Operating System | macOS |

---

# Project Purpose

The application is a Library Management System developed for academic purposes.

The primary objective is to demonstrate:

- MVC Architecture
- Entity Framework Core
- CRUD Operations
- Session Authentication
- Database Design
- Inventory Management
- Pagination
- Search Functionality

The project prioritises readability and maintainability over unnecessary complexity.

---

# Current Modules

The following modules have been implemented.

## Authentication

- Login
- Logout
- Session Management

---

## Dashboard

Provides overall statistics.

Includes:

- Total Books
- Total Students
- Total Librarians
- Total Publications
- Available Books
- Borrowed Books
- Low Stock Books
- Out of Stock Books
- Recent Borrow Records
- Recent Publications

---

## Books

Implemented Features

- Create
- Read
- Update
- Delete
- Search
- Pagination
- Borrow Book
- Inventory Management

Business Rules

- TotalCopies cannot become less than borrowed copies.
- AvailableCopies is automatically updated.
- Borrowing decreases AvailableCopies.

---

## Students

Implemented Features

- CRUD
- Search
- Pagination

---

## Librarians

Implemented Features

- CRUD
- Search
- Pagination

---

## Publications

Single entity.

Uses:

PublicationType Enum

Values

- Magazine
- Newspaper

Implemented Features

- CRUD
- Search
- Pagination

---

## Borrow Records

Stores

- Borrower Name
- Email
- Phone
- Borrow Date
- Book

Borrowing currently exists inside BooksController.

This is intentional.

---

# Database Strategy

Entity Framework Core

Code First

Migrations are used.

Database provider

MySQL

No Repository Pattern is implemented.

Business logic currently resides inside Controllers.

---

# Project Structure

Controllers

Contains MVC controllers.

Models

Contains entities and ViewModels.

Views

Contains Razor Views.

Data

Contains LibraryContext.

Migrations

Entity Framework migrations.

wwwroot

Static files.

---

# Important Design Decisions

## Inventory

The project stores

TotalCopies

AvailableCopies

instead of

IsAvailable

Reason

The library can own multiple copies of the same book.

---

## Borrow Module

Borrow functionality remains inside BooksController.

Reason

Borrowing starts from a selected book.

Creating a separate BorrowController was considered but intentionally not implemented to avoid unnecessary complexity.

---

## Publications

Instead of creating separate Magazine and Newspaper tables,

a single Publication table is used together with PublicationType enum.

This simplifies maintenance.

---

# Coding Conventions

Controllers

One controller per module.

ViewModels

Used whenever a page requires more than one model.

Database

Entity Framework Core only.

No raw SQL.

Naming

PascalCase

Navigation Properties

Used where appropriate.

---

# Pagination

Pagination is implemented manually.

Each module controls

CurrentPage

TotalPages

PageSize

inside a ViewModel.

---

# Search

Search is implemented server-side using Entity Framework LINQ queries.

---

# Authentication

Session based.

Logged-in username is stored inside

HttpContext.Session.

Unauthorised users are redirected to Login.

---

# Things That Should Not Be Changed Without Good Reason

- MVC Architecture
- Entity Framework Core
- Code First approach
- TotalCopies / AvailableCopies design
- PublicationType enum
- Session Authentication

---

# Future Scope

Possible future improvements include

- Role-based authentication
- Fine management
- Email notifications
- Barcode scanning
- Book reservation
- Reports
- Analytics
- Cloud deployment

These are intentionally outside the scope of the current project.

---

# Instructions for Future AI Assistants

Before suggesting architectural changes,

1. Understand the existing MVC architecture.
2. Prefer extending current modules instead of replacing them.
3. Avoid introducing unnecessary design patterns.
4. Maintain consistency with existing coding style.
5. Preserve existing business rules unless explicitly asked to modify them.

When proposing changes,

prefer incremental improvements over complete rewrites.