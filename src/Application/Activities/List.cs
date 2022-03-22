using Application.Common.Mapper;
using Application.DTOs.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Interfaces;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<ActivitiesViewModel> {}
        public class Handler : IRequestHandler<Query, ActivitiesViewModel>
        {
            private readonly IApplicationDbContext context;
            private readonly IMapper mapper;

            public Handler(IApplicationDbContext context, IMapper mapper)
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
