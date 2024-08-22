
using Microsoft.EntityFrameworkCore;
using Task_ToDo.models;


namespace Task_ToDo.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=ASR\\SQLEXPRESS;Initial Catalog=NewDBv2;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }
        public AppDbContext() { }   

    }
}
