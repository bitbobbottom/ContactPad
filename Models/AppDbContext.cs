using Microsoft.EntityFrameworkCore;
using ContactNotePad.Models;
namespace ContactNotePad.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Contacts)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Nickname = "admin", Email = "admin@gmail.com", PasswordHash = "admin" },
            new User { Id = 2, Nickname = "user", Email = "user@gmail.com", PasswordHash = "user" }
        );

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 1,
                UserId = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890",
                Address = "123 Main St",
                Description = "Test contact John",
                CreatedAt = new DateTime(2025, 5, 26, 12, 0, 0)
            },
            new Contact
            {
                Id = 2,
                UserId = 1,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                PhoneNumber = "987-654-3210",
                Address = "456 Oak Ave",
                Description = "Test contact Jane",
                CreatedAt = new DateTime(2025, 5, 26, 12, 0, 0)
            }
        );

    }
}
