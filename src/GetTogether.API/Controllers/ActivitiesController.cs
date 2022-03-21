using Application.Activities;
using Application.Common.Mapper;
using Application.DTOs.Activities;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        private readonly IMapper mapper;

        public ActivitiesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ActivitiesViewModel>> GetActivities()
        {
            var activities = await Mediator.Send(new List.Query());
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDtoBase>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(ActivityDtoBase activity)
        {
            await Mediator.Send(new Create.Command { Activity = activity });
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(Guid id, ActivityDtoBase activity)
        {
            await Mediator.Send(new Edit.Command { Activity = activity, Id = id });
            return Ok();
        }
    }
}
