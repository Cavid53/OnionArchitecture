using DomainLayer.Common;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RepositoryLayer.Common;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AppDbContext : IdentityDbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DatabaseFacade GetDatabase()
        {
            return base.Database;
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity
        {
            return Set<TEntity>();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditingEntity>())
            {
                var utcNow = AppDateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = 0;
                        entry.Entity.CreatedAt = utcNow;
                        entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedAt = utcNow;
                        break;
                    case EntityState.Modified:
                        entry.Property(e => e.CreatedBy).IsModified = false;
                        entry.Property(e => e.CreatedAt).IsModified = false;
                        entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedAt = utcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
