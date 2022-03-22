using Application.Common.Exceptions;
using Application.Common.Mapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity is null)
                {
                    throw new NotFoundException(nameof(ActivityEntity), request.Id);
                }

                // TODO: add soft delete rather than hard delete
                context.Activities.Remove(activity);
                await context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
