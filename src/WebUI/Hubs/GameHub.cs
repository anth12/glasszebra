using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Game.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace CleanArchitecture.WebUI.Hubs
{
	public class GameHub : Hub
	{
		public override Task OnConnectedAsync()
		{
			Context.
			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception exception)
		{

			return base.OnDisconnectedAsync(exception);
		}

		public async Task SendMessage(GameDto game)
		{
			
			await Clients.All.SendAsync("ReceiveMessage", new GameDto
			{
				Name = game.Name + " 1",
				JoinCode = game.JoinCode + " 2"
			});
		}
    }
}
