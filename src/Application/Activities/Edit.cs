using Application.Common.Exceptions;
using Application.Common.Mapper;
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
            private readonly IMapper mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
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
                
                activity.Title = request.Activity.Title ?? activity.Title;
                activity.Description = request.Activity.Description ?? activity.Description;
                activity.City = request.Activity.City ?? activity.City;
                activity.Category = request.Activity.Category ?? activity.Category;
                activity.Date = request.Activity.Date;
                activity.Venue = request.Activity.Venue ?? activity.Venue;

                context.Activities.Update(activity);
                
                await context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
