# PROJECT_CONTEXT.md

# Library Management System
> AI Project Context & Development State

---

# Project Information

**Project Name:** Library Management System

**Framework:** ASP.NET Core MVC (.NET 9)

**Architecture:** MVC

**Language:** C#

**Database:** MySQL

**ORM:** Entity Framework Core

**Provider:** Pomelo.EntityFrameworkCore.MySql

**Frontend:**
- Razor Views
- Bootstrap 5
- HTML
- CSS
- JavaScript

**IDE**
- VS Code

**Operating System**
- macOS
- Apple Silicon (M1)

---

# Project Goal

Initially this project was created as a college assignment.

The assignment has now evolved into a professional Library Management System.

The objective is NOT to blindly copy the assignment.

Instead,

- implement every assignment requirement
- improve architecture
- improve UI
- improve database design
- keep code production-like

---

# Current Architecture

MVC

Controllers

Models

Views

Entity Framework Core

DbContext

MySQL Database

Seed Data

---

# Current Database Tables

## Books

Contains

- BookId
- Title
- Author
- ISBN
- PublishedDate

Inventory Fields

- TotalCopies
- AvailableCopies

IMPORTANT

The project NO LONGER uses

IsAvailable

It has been replaced.

---

## BorrowRecords

Contains

Borrow History

Fields include

BorrowRecordId

BookId

Borrower Name

Borrow Date

Return Date

Navigation Property -> Book

---

# Business Logic

The following business rules MUST NEVER be broken.

---

## Inventory

Books have

TotalCopies

AvailableCopies

BorrowedCopies is NEVER stored.

It is ALWAYS calculated.

Formula

BorrowedCopies = TotalCopies - AvailableCopies

---

## Create Book

When creating a book

AvailableCopies = TotalCopies

Automatically.

User never enters AvailableCopies.

---

## Borrow Book

Before borrowing

if AvailableCopies <= 0

Borrow is NOT allowed.

Borrow action

AvailableCopies--

Create BorrowRecord

---

## Return Book

Return action

AvailableCopies++

ReturnDate = Current DateTime

---

## Double Return

A BorrowRecord cannot be returned twice.

If ReturnDate already exists

Show Already Returned page.

The Return button is disabled in UI.

Server validation still exists.

---

## Editing Books

This is VERY IMPORTANT.

User edits only

Title

Author

ISBN

Published Date

Total Copies

User NEVER edits

AvailableCopies

Algorithm

borrowedCopies =
existingBook.TotalCopies - existingBook.AvailableCopies

Validation

New TotalCopies
must NOT be less than borrowedCopies

AvailableCopies

is recalculated

AvailableCopies =
TotalCopies - borrowedCopies

This logic MUST remain unchanged.

---

# Important Bug Fixed

Entity Framework Tracking Error

Cause

FindAsync()

+

_context.Update(book)

created

two tracked Book objects.

Solution

Current implementation avoids this issue.

DO NOT reintroduce duplicate tracking.

---

# Modules Completed

Books

Status

Completed

Includes

Create

Read

Update

Delete

Inventory

Validation

Bootstrap UI

---

Borrow Module

Completed

---

Return Module

Completed

---

Borrow History

Completed

---

Inventory Management

Completed

Supports

Multiple Copies

Automatic Availability

Professional inventory logic

---

Already Returned

Completed

Fallback page.

---

Not Available

Pending / To Verify

---

# UI

Theme

Green

Bootstrap

Professional cards

Modern tables

Responsive

Do NOT revert UI back to assignment screenshots.

Assignment functionality

Professional UI

---

# Current Folder Structure

Controllers

BooksController

BorrowRecordsController

(HomeController exists)

Models

Book

BorrowRecord

LibraryContext

DbInitializer

Views

Books

BorrowRecords

Shared

Migrations

Existing EF Core migrations

---

# Coding Standards

Always use

Entity Framework Core

Avoid raw SQL unless specifically required.

Avoid duplicate code.

Business logic belongs in Controllers / Services.

Views should stay simple.

Keep validation server-side.

Use Bootstrap.

---

# Assignment Progress

Completed

Books CRUD

Borrow Book

Return Book

Borrow History

Inventory Upgrade

Business Rule Improvements

Pending

Login Module

Dashboard

Student Module

Librarian Module

Authentication

---

# Next Development Order

1.

Login Module

Database Table

LoginModel

LoginController

Login View

Authentication

Session

Logout

---

2.

Dashboard

Statistics

Books

Students

Librarians

Borrowed Books

Available Books

---

3.

Student Module

CRUD

Entity Framework

Validation

---

4.

Librarian Module

CRUD

Entity Framework

Validation

---

5.

Authentication

Session

Authorize

Logout

Protect Routes

---

6.

Documentation

README

Architecture

ER Diagram

Flowcharts

---

# AI Instructions

Whenever continuing this project

DO NOT redesign inventory logic.

DO NOT reintroduce IsAvailable.

DO NOT replace EF Core with raw SQL.

DO NOT remove automatic AvailableCopies calculation.

Maintain current architecture.

Follow production coding practices.

Prefer clean code over assignment code.

Implement assignment features while preserving existing improvements.

If there is a conflict between assignment code and current architecture,

extend the architecture,

do not downgrade it.

---

# Current Development Status

Overall Progress

Approximately

70%

Current Module

Login Module

Ready to Begin

Everything before Login is complete and tested.
