using Backend.Domain.Common;
using Backend.Domain.Feature.Events;
using ErrorOr;

namespace Backend.Domain.Feature;

public class Feature: Entity
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    
    private Feature(string name)
    {
        Name = name;
    }

    public static ErrorOr<Feature> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            return FeatureErrors.FeatureSomeError;
        
        var feature = new Feature(name);

        feature.RaiseEvent(new CreatedFeatureEvent(feature.Id));
        return feature;
    }
}