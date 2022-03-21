using Application.Common.Mapper;
using Application.DTOs.Activities;
using MediatR;
using Persistence;

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
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<ActivityDtoBase> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity is null)
                {
                    //TODO:  throw some custom DataNotFound exception here
                    throw new Exception("Activity is not found.");
                }
                return mapper.MapActivityToDtoBase(activity);
            }
        }
    }
}
