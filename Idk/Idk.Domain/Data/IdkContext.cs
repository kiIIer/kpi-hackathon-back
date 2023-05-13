using Idk.Domain.Model;
using Idk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Task = Idk.Domain.Models.Task;

namespace Idk.Domain.Data
{
    public class IdkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public IdkContext(DbContextOptions<IdkContext> options)
            : base(options)
        {   }

        public IdkContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedOn)
                    .ValueGeneratedOnAddOrUpdate();
            });
            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedOn)
                    .ValueGeneratedOnAddOrUpdate();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.UpdatedOn)
                    .ValueGeneratedOnAddOrUpdate();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
