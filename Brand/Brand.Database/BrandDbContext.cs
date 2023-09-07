using Microsoft.EntityFrameworkCore;

namespace Brand.Database;

public class BrandDbContext : DbContext, IBrandDbContext
{
    public BrandDbContext(DbContextOptions<BrandDbContext> options) : base(options)
    {
    }
}