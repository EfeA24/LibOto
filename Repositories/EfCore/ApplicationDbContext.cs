using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.EfCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Rental> Rentals { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Fiction" },
                new Category { CategoryId = 2, CategoryName = "Non-Fiction" },
                new Category { CategoryId = 3, CategoryName = "Science" },
                new Category { CategoryId = 4, CategoryName = "History" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Description = "A novel set in the 1920s.", TotalPages = 180, CategoryId = 1, DatePublished = new DateTime(1925, 4, 10), IsRented = false },
                new Book { BookId = 2, Title = "Sapiens: A Brief History of Humankind", Author = "Yuval Noah Harari", Description = "A book about the history of humankind.", TotalPages = 443, CategoryId = 2, DatePublished = new DateTime(2011, 1, 1), IsRented = false },
                new Book { BookId = 3, Title = "A Brief History of Time", Author = "Stephen Hawking", Description = "A popular-science book on cosmology.", TotalPages = 256, CategoryId = 3, DatePublished = new DateTime(1988, 4, 1), IsRented = false },
                new Book { BookId = 4, Title = "The Diary of a Young Girl", Author = "Anne Frank", Description = "The diary of a Jewish girl during World War II.", TotalPages = 283, CategoryId = 4, DatePublished = new DateTime(1947, 6, 25), IsRented = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = "1", UserName = "john.doe", FullName = "John Doe", NormalizedUserName = "JOHN.DOE", Email = "john.doe@example.com", NormalizedEmail = "JOHN.DOE@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "hashed_password_1", SecurityStamp = "stamp_1" },
                new User { Id = "2", UserName = "jane.smith", FullName = "Jane Smith", NormalizedUserName = "JANE.SMITH", Email = "jane.smith@example.com", NormalizedEmail = "JANE.SMITH@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "hashed_password_2", SecurityStamp = "stamp_2" }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental { RentId = 1, BookId = 1, UserId = "1", IsApproved = true, RentalDate = DateTime.Now, ReturnDate = null },
                new Rental { RentId = 2, BookId = 2, UserId = "2", IsApproved = true, RentalDate = DateTime.Now, ReturnDate = null }
            );
        }
    }
}