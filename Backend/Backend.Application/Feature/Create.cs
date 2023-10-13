using Backend.Application.Data;
using MediatR;
using ErrorOr;

namespace Backend.Application.Feature;

public class Create
{
    public record Command(int Id, string Name) : IRequest<ErrorOr<Response>>;

    public record Response(int Id);

    public class CommandHandler : IRequestHandler<Command, ErrorOr<Response>>
    {
        private readonly IBackendDBContext _context;
        public CommandHandler(IBackendDBContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var newEntity = Domain.Feature.Feature.Create(request.Name);
            _context.Features.Add(newEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response(newEntity.Id);
        }
    }
}