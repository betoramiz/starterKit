namespace Backend.Domain.Feature;

public class Feature
{
    public int Id { get; private set; }
    public string? Name { get; private set; }
    
    private Feature(string name)
    {
        Name = name;
    }

    public static Feature Create(string name)
    {
        return new Feature(name);
    }
}