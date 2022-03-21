using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<ActivityEntity>> {}
        public class Handler : IRequestHandler<Query, List<ActivityEntity>>
        {
            private readonly ApplicationDbContext context;
            public Handler(ApplicationDbContext context)
            {
                this.context = context;
            }

            public Task<List<ActivityEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return context.Activities.ToListAsync();
            }
        }
    }
}
