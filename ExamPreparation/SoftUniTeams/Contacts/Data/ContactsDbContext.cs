using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; } = null!;

        public DbSet<UserContact> UsersContacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserContact>()
                .HasKey(uc => new { uc.UserId, uc.ContactId });

            builder
                .Entity<Contact>()
                .HasData(new Contact()
                {
                    Id = 1,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    PhoneNumber = "+359881223344",
                    Address = "Gotham City",
                    Email = "imbatman@batman.com",
                    Website = "www.batman.com"
                });

            base.OnModelCreating(builder);
        }
    }
}