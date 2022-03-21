using Application.Common.Exceptions;
using Application.DTOs.Activities;
using Domain.Entities;
using MediatR;
using Persistence;

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
            private readonly ApplicationDbContext context;

            public Handler(ApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);

                if (activity is null)
                {
                    throw new NotFoundException(nameof(ActivityEntity), request.Id);
                }
                
                activity.Title = request.Activity.Title ?? activity.Title;
                activity.Description = request.Activity.Description ?? activity.Description;
                
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
