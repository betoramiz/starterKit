﻿using Backend.Application.Data;
using MediatR;
using ErrorOr;

namespace Backend.Application.Feature;

public class Create
{
    public record Command(int Id, string Name) : IRequest<ErrorOr<Response>>;

    public record Response(int Id);

    public class CommandHandler : IRequestHandler<Command, ErrorOr<Response>>
    {
        private readonly IBackendDbContext _context;
        public CommandHandler(IBackendDbContext context) => _context = context;

        public async Task<ErrorOr<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var newEntity = Domain.Feature.Feature.Create(request.Name);
            if (newEntity.IsError)
                return newEntity.Errors;
            
            _context.Features.Add(newEntity.Value);
            await _context.SaveChangesAsync(cancellationToken);

            return new Response(newEntity.Value.Id);
        }
    }
}