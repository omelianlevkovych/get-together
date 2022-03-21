using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Edit
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
                var activity = await context.Activities.FindAsync(request.Activity.Id);

                // possible null ref exception
                
                activity.Title = request.Activity.Title ?? activity.Title;
                activity.Description = request.Activity.Description ?? activity.Description;
                
                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
