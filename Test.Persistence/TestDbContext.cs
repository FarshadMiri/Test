using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Persistence
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.UpdatedDateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDateTime = DateTime.Now;
                }
            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.UpdatedDateTime = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDateTime = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }


    }
}
