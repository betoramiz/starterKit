using ErrorOr;

namespace Backend.Domain.Feature;

public class Feature
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
        
        return new Feature(name);
    }
}