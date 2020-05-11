using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitecture.Application.Game.Commands;
using CleanArchitecture.Application.Game.Commands.CreateGame;
using CleanArchitecture.Application.Game.Commands.JoinGame;
using CleanArchitecture.Application.Game.Commands.UpdateGame;
using CleanArchitecture.Application.Game.Commands.UpdateParticipantStatus;
using CleanArchitecture.Application.Game.Dtos;
using CleanArchitecture.Application.Game.Queries.GetGame;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.WebUI.Controllers
{
    public class GameController : ApiController
    {
	    [HttpPost]
	    public async Task<ActionResult<CreateGameResponse>> Create(CreateGameCommand command)
	    {
		    return await Mediator.Send(command);
	    }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<GameDto>> Get(Guid clientId)
        {
            return await Mediator.Send(new GetGameQuery{ ClientId = clientId});
        }

        [HttpPost("[action]/{joinCode}")]
        public async Task<ActionResult<JoinGameResponse>> Join(string joinCode)
        {
            return await Mediator.Send(new JoinGameCommand
            {
                JoinCode = joinCode
            });
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateGameCommand command)
        {
	        await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Leave(ParticipantGameCommand command)
        {
	        await Mediator.Send(new UpdateParticipantStatusCommand
	        {
                NewStatus = ParticipantStatus.Left,
                GameClientId = command.GameClientId,
                ParticipantClientId = command.ParticipantClientId
	        });
	        return NoContent();
        }
    }
}
