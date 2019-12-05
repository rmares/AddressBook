namespace AddressBook.Infrastructure.Domain
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }
    }
}