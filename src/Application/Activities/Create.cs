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
            public ActivityDtoBase Activity { get; set; } = new ActivityDtoBase();
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
                var activity = mapper.MapActivityDtoBaseToEntity(request.Activity);
                context.Activities.Add(activity);

                await context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
