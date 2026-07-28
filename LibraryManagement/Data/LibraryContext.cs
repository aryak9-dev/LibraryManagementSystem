using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
// using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<LibrarianModel> Librarians { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        // public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publication> Publications { get; set; }

        public DbSet<BorrowRecord> BorrowRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<Book>().HasData(
            
                new Book
                {
                    BookId = 1,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt and David Thomas",
                    ISBN = "978-0201616224",
                    PublishedDate = new DateTime(2021, 10, 30),
                    TotalCopies = 5,
                    AvailableCopies = 5
                },
        
                new Book
                {
                    BookId = 2,
                    Title = "Design Pattern using C#",
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884",
                    PublishedDate = new DateTime(2023, 8, 1),
                    TotalCopies = 5,
                    AvailableCopies = 5
                },
        
                new Book
                {
                    BookId = 3,
                    Title = "Mastering ASP.NET Core",
                    Author = "Pranaya Kumar Rout",
                    ISBN = "978-0451616235",
                    PublishedDate = new DateTime(2022, 11, 22),
                    TotalCopies = 5,
                    AvailableCopies = 5
                },
        
                new Book
                {
                    BookId = 4,
                    Title = "SQL Server with DBA",
                    Author = "Rakesh Kumar",
                    ISBN = "978-4562350123",
                    PublishedDate = new DateTime(2020, 8, 15),
                    TotalCopies = 5,
                    AvailableCopies = 5
                }
        
            );

            modelBuilder.Entity<LoginModel>().HasData(
                new LoginModel
                {
                    Id = 1,
                    Username = "admin",
                    Password = "12345"
                },
                new LoginModel
                {
                    Id = 2,
                    Username = "mycodingproject",
                    Password = "myc546"
                },
                new LoginModel
                {
                    Id = 3,
                    Username = "my",
                    Password = "myc"
                }
            );


            modelBuilder.Entity<StudentModel>().HasData(

                new StudentModel
                {
                    StudentId = 1,
                    StudentName = "Alice Johnson",
                    Email = "alice.j@email.com",
                    Phone = "555-0101"
                },

                new StudentModel
                {
                    StudentId = 2,
                    StudentName = "Bob Smith",
                    Email = "bob.smith@email.com",
                    Phone = "555-0102"
                },

                new StudentModel
                {
                    StudentId = 3,
                    StudentName = "Charlie Brown",
                    Email = "charlie.b@email.com",
                    Phone = "555-0103"
                },

                new StudentModel
                {
                    StudentId = 4,
                    StudentName = "Diana Prince",
                    Email = "diana.p@email.com",
                    Phone = "555-0104"
                },

                new StudentModel
                {
                    StudentId = 5,
                    StudentName = "Evan Wright",
                    Email = "evan.w@email.com",
                    Phone = "555-0105"
                }
            );


            modelBuilder.Entity<LibrarianModel>().HasData(
            
                new LibrarianModel
                {
                    LibrarianId = 1,
                    Name = "Sarah Connor",
                    Age = 34,
                    Phone = "555-0201"
                },
            
                new LibrarianModel
                {
                    LibrarianId = 2,
                    Name = "John Doe",
                    Age = 28,
                    Phone = "555-0202"
                },
            
                new LibrarianModel
                {
                    LibrarianId = 3,
                    Name = "Michael Scott",
                    Age = 45,
                    Phone = "555-0203"
                },
            
                new LibrarianModel
                {
                    LibrarianId = 4,
                    Name = "Ellen Ripley",
                    Age = 39,
                    Phone = "555-0204"
                },
            
                new LibrarianModel
                {
                    LibrarianId = 5,
                    Name = "James Bond",
                    Age = 40,
                    Phone = "555-0205"
                }
            );

            modelBuilder.Entity<Publication>().HasData(

                new Publication
                {
                    PublicationId = 1,
                    Title = "National Geographic",
                    Publisher = "National Geographic",
                    PublishedDate = new DateTime(2025,1,15),
                    Type = PublicationType.Magazine,
                    TotalCopies = 10,
                    AvailableCopies = 10
                },
            
                new Publication
                {
                    PublicationId = 2,
                    Title = "Forbes",
                    Publisher = "Forbes",
                    PublishedDate = new DateTime(2025,2,10),
                    Type = PublicationType.Magazine,
                    TotalCopies = 6,
                    AvailableCopies = 6
                },
            
                new Publication
                {
                    PublicationId = 3,
                    Title = "The Hindu",
                    Publisher = "The Hindu",
                    PublishedDate = new DateTime(2025,7,1),
                    Type = PublicationType.Newspaper,
                    TotalCopies = 15,
                    AvailableCopies = 15
                },
            
                new Publication
                {
                    PublicationId = 4,
                    Title = "Times of India",
                    Publisher = "TOI",
                    PublishedDate = new DateTime(2025,7,2),
                    Type = PublicationType.Newspaper,
                    TotalCopies = 12,
                    AvailableCopies = 12
                }
            
            );











        }
    }
}