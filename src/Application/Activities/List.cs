using Application.Common.Mapper;
using Application.DTOs.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<ActivitiesViewModel> {}
        public class Handler : IRequestHandler<Query, ActivitiesViewModel>
        {
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<ActivitiesViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                return new ActivitiesViewModel
                {
                    Activities = await context.Activities
                    .AsNoTracking()
                    .OrderBy(x => x.Title)
                    .Select(x => mapper.MapActivityToDto(x))
                    .ToListAsync()
                };
            }
        }
    }
}
