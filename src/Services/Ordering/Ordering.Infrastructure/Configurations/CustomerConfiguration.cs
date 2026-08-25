namespace Ordering.Infrastructure.Configurations;


/*
    This is an EF Core configuration class that defines how the Order entity maps to a database table It tells EF Core:

        Which properties map to database columns
        Data types and constraints (max length, required/optional)
        Relationships between entities
        Default values and type conversions

*/


internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        /*
            your database doesn't know what CustomerId is.
        
            1 - C# → Database(customerId => customerId.Value) : When saving a CustomerId to the database, take its Value.
            2 - Database → C# When reading the ID from the database, create a CustomerId from the Guid

         */
        builder.Property(c => c.Id).HasConversion(customerId => customerId.Value, dbId => CustomerId.Of(dbId));

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();
    }
}
