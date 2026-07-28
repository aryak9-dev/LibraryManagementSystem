# Entity Framework Core

## What is DbContext?

DbContext is the main class that manages communication between the application and the database.

## What is DbSet?

DbSet<T> represents a table in the database.

Examples:

- DbSet<Book>
- DbSet<BorrowRecord>

## Relationship

Book (1)

↓

BorrowRecord (Many)

One book can have many borrow records.
