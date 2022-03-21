using Application.Common.Mapper;
using Application.DTOs.Activities;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public ActivityDto Activity { get; set; } = new ActivityDto();
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = mapper.MapActivityDtoToEntity(request.Activity);
                context.Activities.Add(activity);

                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
