namespace Backend.Domain.Common;

public class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearEvents() => _domainEvents.Clear();
    
    public void RaiseEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

}