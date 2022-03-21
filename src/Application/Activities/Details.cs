using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<ActivityEntity?> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ActivityEntity?>
        {
            private readonly ApplicationDbContext context;

            public Handler(ApplicationDbContext context)
            {
                this.context = context;
            }

            public async Task<ActivityEntity?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.FindAsync(request.Id);
            }
        }
    }
}
