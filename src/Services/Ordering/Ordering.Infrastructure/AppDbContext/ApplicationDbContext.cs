using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.AppDbContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

}
