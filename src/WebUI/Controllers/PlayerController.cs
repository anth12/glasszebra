using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Game.Commands.RemovePlayer;
using NSwag.Annotations;

namespace GlassZebra.WebUI.Controllers
{
    public class PlayerController : ApiController
    {
	    [HttpPost]
	    [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))] // TODO move common response types to generic config
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult> Remove(RemovePlayerCommand command)
        {
	        await Mediator.Send(command);
	        return NoContent();
        }

    }
}
