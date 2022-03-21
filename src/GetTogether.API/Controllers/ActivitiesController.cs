using Application.Activities;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<ActivityEntity>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityEntity>> GetActivity(Guid id)
        {
            var activity = await Mediator.Send(new Details.Query{Id = id});
            return (activity is not null) ? Ok(activity) : NotFound();
        }
    }
}
