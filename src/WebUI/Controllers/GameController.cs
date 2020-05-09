using System;
using CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitecture.Application.Game.CreateGame;
using CleanArchitecture.Application.Game.JoinGame;
using GetGameResponse = CleanArchitecture.Application.Game.CreateGame.GetGameResponse;

namespace CleanArchitecture.WebUI.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
	    [HttpPost]
	    public async Task<ActionResult<GetGameResponse>> Create(GetGameCommand command)
	    {
		    return await Mediator.Send(command);
	    }

        [HttpPost]
        public async Task<ActionResult<GetGameResponse>> Create(GetGameCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("{joinCode}")]
        public async Task<ActionResult<JoinGameResponse>> Update(string joinCode)
        {
            return await Mediator.Send(new JoinGameCommand
            {
                JoinCode = joinCode
            });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
