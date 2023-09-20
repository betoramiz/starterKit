using Carter;

namespace Backend.Features.FeatureA;

public class Endpoints: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var appGroup = app.MapGroup("featureA");
        
        appGroup.MapPost("", Create.CreateEmployee);
        // appGroup.MapGet("/all", GetAll.Execute);
        // appGroup.MapGet("{id:int}", GetById.Execute);
    }
}