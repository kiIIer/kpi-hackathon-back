using Idk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Idk.Domain.Data
{
    public class IdkContext : DbContext
    {
        public DbSet<Idk.Domain.Models.Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public IdkContext(DbContextOptions<IdkContext> options)
            : base(options)
        {   }

        public IdkContext()
        {
            //Database.EnsureCreated();
        }
    }
}
