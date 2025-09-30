using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class TrainDbContext : DbContext
    {
        public TrainDbContext(DbContextOptions<TrainDbContext> options) : base(options) { }

        public DbSet<Train> Trains => Set<Train>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            // Entity
            b.Entity<Train>().ToTable("Trains");

            // Primary key
            b.Entity<Train>().HasKey(t => t.Id);

            // Attributes
            b.Entity<Train>()
                .Property(t => t.TrainNumber)
                .IsRequired()
                .HasMaxLength(5);

            // Unique index on TrainNumber
            b.Entity<Train>()
                .HasIndex(t => t.TrainNumber)
                .IsUnique();

            // Enum as int (default) - kompakt and fast 
            b.Entity<Train>()
                .Property(t => t.TrainType)
                .HasConversion<int>();

            // Create/update times (we set values in SaveChanges)
            b.Entity<Train>()
                .Property(t => t.Created)
                .IsRequired();

            b.Entity<Train>()
                .Property(t => t.Updated)
                .IsRequired();

            // Seed - determine GUIDs for migration
            var t1 = Train.Create("73271", TrainType.Passenger);
            var t2 = Train.Create("73272", TrainType.Service);

            b.Entity<Train>().HasData(t1, t2);
        }
       
        // Automatic timestamp
        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            foreach (var e in ChangeTracker.Entries<Train>())
            {
              if (e.State == EntityState.Modified)
                {
                    e.Entity.UpdateTime();
                }
            }

            return base.SaveChangesAsync(ct);
        }
    }
}
