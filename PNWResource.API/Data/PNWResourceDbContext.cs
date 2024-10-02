using Microsoft.EntityFrameworkCore;
using PNWResource.API.Entities;

namespace PNWResource.API.Data
{
    public class PNWResourceDbContext : DbContext
    {
        public DbSet<City> Cities {  get; set; }
        public DbSet<DaycareCenter> DaycareCenters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Library> Library { get; set; }
        public DbSet<Park> Park { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        public PNWResourceDbContext(DbContextOptions<PNWResourceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // City -> DaycareCenter
            modelBuilder.Entity<City>()
                .HasMany(c => c.DaycareCenters)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> Event
            modelBuilder.Entity<City>()
                .HasMany(c => c.Events)
                .WithOne(e => e.City)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> Library
            modelBuilder.Entity<City>()
                .HasMany(c => c.Librarys)
                .WithOne(l => l.City)
                .HasForeignKey(l => l.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> Park
            modelBuilder.Entity<City>()
                .HasMany(c => c.Parks)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> Playground
            modelBuilder.Entity<City>()
                .HasMany(c => c.Playgrounds)
                .WithOne(pg => pg.City)
                .HasForeignKey(pg => pg.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> School
            modelBuilder.Entity<City>()
                .HasMany(c => c.Schools)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // City -> Zoo
            modelBuilder.Entity<City>()
                .HasMany(c => c.Zoos)
                .WithOne(z => z.City)
                .HasForeignKey(z => z.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            // Park -> Playground (Optional)
            modelBuilder.Entity<Park>()
                .HasOne(p => p.Playground)
                .WithOne()
                .HasForeignKey<Park>(p => p.PlaygroundId)
                .OnDelete(DeleteBehavior.SetNull);

            // Library <-> Event (Many-to-Many)
            modelBuilder.Entity<LibraryEvent>()
                .HasKey(le => new { le.LibraryId, le.EventId });
            modelBuilder.Entity<LibraryEvent>()
                .HasOne(le => le.Library)
                .WithMany(l => l.LibraryEvents)
                .HasForeignKey(le => le.LibraryId);
            modelBuilder.Entity<LibraryEvent>()
                .HasOne(le => le.Event)
                .WithMany(e => e.LibraryEvents)
                .HasForeignKey(le => le.EventId);

            // Park <-> Event (Many-to-Many)
            modelBuilder.Entity<ParkEvent>()
                .HasKey(pe => new { pe.ParkId, pe.EventId });
            modelBuilder.Entity<ParkEvent>()
                .HasOne(pe => pe.Park)
                .WithMany(p => p.ParkEvents)
                .HasForeignKey(pe => pe.ParkId);
            modelBuilder.Entity<ParkEvent>()
                .HasOne(pe => pe.Event)
                .WithMany(e => e.ParkEvents)
                .HasForeignKey(pe => pe.EventId);

            // Playground <-> Event (Many-to-Many)
            modelBuilder.Entity<PlaygroundEvent>()
                .HasKey(pe => new { pe.PlaygroundId, pe.EventId });
            modelBuilder.Entity<PlaygroundEvent>()
                .HasOne(pe => pe.Playground)
                .WithMany(pg => pg.PlaygroundEvents)
                .HasForeignKey(pe => pe.PlaygroundId);
            modelBuilder.Entity<PlaygroundEvent>()
                .HasOne(pe => pe.Event)
                .WithMany(e => e.PlaygroundEvents)
                .HasForeignKey(pe => pe.EventId);

            // School <-> Event (Many-to-Many)
            modelBuilder.Entity<SchoolEvent>()
                .HasKey(se => new { se.SchoolId, se.EventId });
            modelBuilder.Entity<SchoolEvent>()
                .HasOne(se => se.School)
                .WithMany(s => s.SchoolEvents)
                .HasForeignKey(se => se.SchoolId);
            modelBuilder.Entity<SchoolEvent>()
                .HasOne(se => se.Event)
                .WithMany(e => e.SchoolEvents)
                .HasForeignKey(se => se.EventId);

            // DaycareCenter <-> Event (Many-to-Many)
            modelBuilder.Entity<DaycareCenterEvent>()
                .HasKey(dce => new { dce.DaycareCenterId, dce.EventId });
            modelBuilder.Entity<DaycareCenterEvent>()
                .HasOne(dce => dce.DaycareCenter)
                .WithMany(d => d.DaycareCenterEvents)
                .HasForeignKey(dce => dce.DaycareCenterId);
            modelBuilder.Entity<DaycareCenterEvent>()
                .HasOne(dce => dce.Event)
                .WithMany(e => e.DaycareCenterEvents)
                .HasForeignKey(dce => dce.EventId);

            // Zoo <-> Event (Many-to-Many)
            modelBuilder.Entity<ZooEvent>()
                .HasKey(ze => new { ze.ZooId, ze.EventId });
            modelBuilder.Entity<ZooEvent>()
                .HasOne(ze => ze.Zoo)
                .WithMany(z => z.ZooEvents)
                .HasForeignKey(ze => ze.ZooId);
            modelBuilder.Entity<ZooEvent>()
                .HasOne(ze => ze.Event)
                .WithMany(e => e.ZooEvents)
                .HasForeignKey(ze => ze.EventId);
        }
    }
}
