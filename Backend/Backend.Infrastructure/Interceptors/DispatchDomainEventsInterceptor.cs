using Backend.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Infrastructure.Interceptors;

public class DispatchDomainEventsInterceptor(IPublisher publisher) : SaveChangesInterceptor
{
    private readonly IPublisher _publisher = publisher;

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if(eventData.Context is not null)
            DispatchEvents(eventData.Context);
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void DispatchEvents(DbContext context)
    {
        var entities = context
            .ChangeTracker
            .Entries<Entity>()
            .Where(entity => entity.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();
        
        entities.ToList().ForEach(e => e.ClearEvents());

        foreach (var domainEvent in domainEvents) 
            _publisher.Publish(domainEvent);
    }
}