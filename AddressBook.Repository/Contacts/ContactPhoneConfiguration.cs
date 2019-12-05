using AddressBook.Core.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AddressBook.Repository.Contacts
{
    public class ContactPhoneConfiguration : IEntityTypeConfiguration<ContactPhone>
    {
        public void Configure(EntityTypeBuilder<ContactPhone> builder)
        {
            builder
                .ToTable("ContactPhone");

            builder
                .Property<int>("ContactId")
                .IsRequired();

            builder
                .Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}