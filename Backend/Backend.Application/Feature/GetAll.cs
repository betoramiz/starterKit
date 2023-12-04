using Backend.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ErrorOr;

namespace Backend.Application.Feature;

public class GetAll
{
    public record Query() : IRequest<ErrorOr<List<Response>>>;

    public record Response(int Id, string? Name);

    public class CommandHandler : IRequestHandler<Query, ErrorOr<List<Response>>>
    {
        private readonly IBackendDbContext _context;
        public CommandHandler(IBackendDbContext context) => _context = context;

        public async Task<ErrorOr<List<Response>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var features = await _context.Features
                .Select(x => new Response(x.Id, x.Name))
                .ToListAsync(cancellationToken);
            
            return features;
        }
    }
}