using AddressBook.Core.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Repository.Contacts
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder
                .ToTable("Contact");

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(b => b.DateOfBirth)
                .IsRequired();

            builder
                .Property(b => b.Address)
                .IsRequired();
        }
    }
}