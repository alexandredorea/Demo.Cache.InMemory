using Demo.Cache.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Cache.Api.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; } = null!;
}