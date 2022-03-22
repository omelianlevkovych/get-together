using Application.Common.Exceptions;
using Application.DTOs.Activities;
using Domain.Entities;
using MediatR;
using Persistence.Interfaces;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ActivityDtoBase Activity { get; set; } = new ActivityDtoBase();
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IApplicationDbContext context;

            public Handler(IApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id, cancellationToken);

                if (activity is null)
                {
                    throw new NotFoundException(nameof(ActivityEntity), request.Id);
                }
                
                activity.Title = request.Activity.Title ?? activity.Title;
                activity.Description = request.Activity.Description ?? activity.Description;
                
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
