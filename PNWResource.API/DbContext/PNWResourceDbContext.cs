using Microsoft.EntityFrameworkCore;
using PNWResource.API.Entities;

namespace PNWResource.API.Data
{
    public class PNWResourceDbContext : DbContext
    {
        public DbSet<City> Cities {  get; set; }
        public DbSet<DaycareCenter> DaycareCenters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Playground> Playgrounds { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Zoo> Zoos { get; set; }

        public PNWResourceDbContext(DbContextOptions<PNWResourceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                 .HasData(
                new City()
                {
                    Id = 1,
                    Name = "Portland",
                    State = "OR"
                },
                new City()
                {
                    Id = 2,
                    Name = "Salem",
                    State = "OR"
                },
                new City()
                {
                    Id = 3,
                    Name = "Vancouver",
                    State = "WA"
                });

            modelBuilder.Entity<Playground>()
             .HasData(
               new Playground()
               {
                   Id = 1,
                   Name = "Adventure Cove",
                   CityId = 1,

               },
               new Playground()
               {
                   Id = 2,
                   Name = "Sunny Meadows Park",
                   CityId = 1,
               },
                 new Playground()
                 {
                     Id = 3,
                     Name = "Jungle Jumper Playground",
                     CityId = 2,
                 },
               new Playground()
               {
                   Id = 4,
                   Name = "Splash & Dash Park",
                   CityId = 2,
               },
               new Playground()
               {
                   Id = 5,
                   Name = "Little Explorers Park",
                   CityId = 3,
               },
               new Playground()
               {
                   Id = 6,
                   Name = "Rainbow Slide Haven",
                   CityId = 3,
               }
               );

            modelBuilder.Entity<Event>()
             .HasData(
                new Event()
                {
                    Id = 1,
                    Name = "Adventure Cove",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 1,

                },
                new Event()
                {
                    Id = 2,
                    Name = "Sunny Meadows Run",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 1,
                },
                new Event()
                {
                    Id = 3,
                    Name = "Jungle Jumper Play Time",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 2,
                },
                new Event()
                {
                    Id = 4,
                    Name = "Splash & Dash Park & Slide",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 2,
                },
                new Event()
                {
                    Id = 5,
                    Name = "Little Explorers Find and Seek",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 3,
                },
                new Event()
                {
                    Id = 6,
                    Name = "Rainbow Slide and Dive",
                    TimeStarts = "11:00am",
                    TimeEnds = "2:00pm",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    CityId = 3,
                }
             );


            //base.OnModelCreating(modelBuilder);

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
        }
    }
}
