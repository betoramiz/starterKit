using Backend.Application.Data;
using Backend.Domain.Feature;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistance;

public class BackendContext: DbContext, IBackendDBContext
{
    public BackendContext(DbContextOptions<BackendContext> options) : base(options) { }


    public DbSet<Feature> Features { get; set; }
}