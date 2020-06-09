using Microsoft.EntityFrameworkCore;
using SA.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sa.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentProfessorChoices> StudentProfessorChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
            .HasMany(c => c.Users)
            .WithOne(e => e.Role);
        }
    }
}

