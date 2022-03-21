using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public ActivityEntity Activity { get; set; } = new ActivityEntity();
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext context;

            public Handler(ApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);

                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
