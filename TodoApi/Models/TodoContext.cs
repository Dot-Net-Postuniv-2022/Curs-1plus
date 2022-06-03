using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TodoContext(DbContextOptions<TodoContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("TodoItemsConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Email = "vlad.ionescu@ubbcluj.ro",
                    FirstName = "Vlad",
                    LastName = "Ionescu",
                    CreatedAt = DateTime.Now
                }
            );
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        public DbSet<TodoSubItem> TodoSubItems { get; set; } = null!;
        public DbSet<UserInfo> Users { get; set; } = null!;
    }
}