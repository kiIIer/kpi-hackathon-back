﻿using Idk.Domain.Model;
using Idk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Idk.Domain.Data
{
    public class IdkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public IdkContext(DbContextOptions<IdkContext> options)
            : base(options)
        {   }

        public IdkContext()
        {
            
        }
    }
}
