namespace Backend.Domain.Feature;
using ErrorOr;

public static class FeatureErrors
{
    public static readonly Error FeatureSomeError =
        Error.Validation("Feature.SomeDescriptiveErrorFound", "Some Descriptive Error");
}