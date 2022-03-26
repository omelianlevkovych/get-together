using Application.Common.Exceptions;
using Application.Common.Mapper;
using Application.DTOs.Activities;
using Domain.Entities;
using MediatR;
using Persistence.Interfaces;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<ActivityDto> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ActivityDto>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<ActivityDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity is null)
                {
                    throw new NotFoundException(nameof(ActivityEntity), request.Id);
                }
                return mapper.MapActivityToDto(activity);
            }
        }
    }
}
