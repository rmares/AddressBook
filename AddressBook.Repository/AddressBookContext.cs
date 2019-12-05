using AddressBook.Core.Contacts;
using AddressBook.Repository.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repository
{
    public class AddressBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPhone> ContactPhones { get; set; }

        public AddressBookContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContactPhoneConfiguration());
        }
    }
}