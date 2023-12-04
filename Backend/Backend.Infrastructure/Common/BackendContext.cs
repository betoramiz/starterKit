using Backend.Application.Data;
using Backend.Infrastructure.Feature;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Common;

public class BackendContext: DbContext, IBackendDbContext
{
    public BackendContext(DbContextOptions<BackendContext> options) : base(options) { }


    public DbSet<Domain.Feature.Feature> Features { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FeatureConfiguration());
    }
}