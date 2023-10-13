using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Data;

public interface IBackendDBContext
{
    public DbSet<Domain.Feature.Feature> Features { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}