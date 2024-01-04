using Backend.Domain.Common;

namespace Backend.Domain.Feature.Events;

public record CreatedFeatureEvent(int Id): IDomainEvent { }