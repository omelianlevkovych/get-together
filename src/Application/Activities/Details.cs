using Application.Common.Exceptions;
using Application.Common.Mapper;
using Application.DTOs.Activities;
using Domain.Entities;
using MediatR;
using Persistence;
using Persistence.Interfaces;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<ActivityDtoBase> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ActivityDtoBase>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<ActivityDtoBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity is null)
                {
                    throw new NotFoundException(nameof(ActivityEntity), request.Id);
                }
                return mapper.MapActivityToDtoBase(activity);
            }
        }
    }
}
