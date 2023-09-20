using FluentValidation;

namespace Backend.Features.FeatureA;

public class Create
{
    public sealed record Command(string Name);
    
    public class Validator: AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
    
    public static IResult CreateEmployee(HttpRequest request, Command employee)
    {
        throw new NotImplementedException();
    }
}