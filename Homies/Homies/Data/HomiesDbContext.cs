using Homies.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Homies.Data.Models.Type;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<Type> Types { get; set; } = null!;

        public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;

        private IdentityUser testUser = null!;
        private Event testEvent = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.HelperId });

            modelBuilder
                .Entity<Event>()
                .HasMany(e => e.EventsParticipants)
                .WithOne(ep => ep.Event)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder
                .Entity<Type>()
                .HasData(new Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            CreateTestUser();
            CreateTestEvent();

            modelBuilder
                .Entity<IdentityUser>()
                .HasData(testUser);

            modelBuilder
                .Entity<Event>() 
                .HasData(testEvent);


            base.OnModelCreating(modelBuilder);
        }

        private void CreateTestUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            testUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            testUser.PasswordHash = hasher.HashPassword(testUser, "softuni");
        }

        private void CreateTestEvent()
        {
            testEvent = new Event()
            {
                Id = 1,
                Name = "Test Event",
                Description = "Testing the event description",
                OrganiserId = testUser.Id,
                CreatedOn = DateTime.Now,
                Start = DateTime.Now.AddDays(1),
                End = DateTime.Now.AddDays(3),
                TypeId = 1,
            };
        }
    }
}