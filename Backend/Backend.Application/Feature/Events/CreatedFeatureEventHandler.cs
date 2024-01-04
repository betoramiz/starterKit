using Backend.Domain.Feature.Events;
using MediatR;

namespace Backend.Application.Feature.Events;

public class CreatedFeatureEventHandler: INotificationHandler<CreatedFeatureEvent>
{
    public Task Handle(CreatedFeatureEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("Created Feature");
        
        return Task.CompletedTask;
    }
}