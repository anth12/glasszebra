using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Game.Commands;
using GlassZebra.Application.Game.Commands.CreateGame;
using GlassZebra.Application.Game.Commands.JoinGame;
using GlassZebra.Application.Game.Commands.UpdateGame;
using GlassZebra.Application.Game.Commands.UpdatePlayerStatus;
using GlassZebra.Application.Game.Dtos;
using GlassZebra.Application.Game.Queries.GetGame;
using GlassZebra.Application.Game.Queries.GetGameOptions;
using GlassZebra.Domain.Enums;
using NSwag.Annotations;

namespace GlassZebra.WebUI.Controllers
{
    public class GameController : ApiController
    {
	    [HttpPost]
	    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateGameResponse))]
	    [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))] // TODO move common response types to generic config
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult<CreateGameResponse>> Create(CreateGameCommand command)
	    {
		    return await Mediator.Send(command);
	    }

        [HttpPost("[action]")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(GetGameOptionsResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult<GetGameOptionsResponse>> Options()
        {
	        return await Mediator.Send(new GetGameOptionsQuery());
        }

        [HttpGet("{clientId}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(GameDto))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult<GameDto>> Get(Guid clientId)
        {
            return await Mediator.Send(new GetGameQuery{ ClientId = clientId});
        }

        [HttpPost("[action]/{joinCode}")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(JoinGameResponse))]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult<JoinGameResponse>> Join(string joinCode)
        {
            return await Mediator.Send(new JoinGameCommand
            {
                JoinCode = joinCode
            });
        }

        [HttpPut]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult> Update(UpdateGameCommand command)
        {
	        await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("[action]")]
        [SwaggerResponse(HttpStatusCode.NotFound, typeof(NotFoundException))]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(ValidationException))]
        public async Task<ActionResult> Leave(PlayerGameCommand command)
        {
	        await Mediator.Send(new UpdatePlayerStatusCommand
	        {
                NewStatus = PlayerStatus.Left,
                GameClientId = command.GameClientId,
                PlayerClientId = command.PlayerClientId
	        });
	        return NoContent();
        }
    }
}
