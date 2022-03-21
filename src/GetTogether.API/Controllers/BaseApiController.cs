using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator? mediator;
        protected IMediator Mediator
        {
            get
            {
                if (mediator is null)
                {
                    mediator = HttpContext.RequestServices.GetRequiredService<IMediator>();
                    ArgumentNullException.ThrowIfNull(mediator);
                }
                return mediator;
            }
        }
    }
}
