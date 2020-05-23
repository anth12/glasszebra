using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Game.Commands.UpdatePlayerStatus;
using CleanArchitecture.Application.Game.Dtos;
using CleanArchitecture.Application.Game.Queries.GetGame;
using CleanArchitecture.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace CleanArchitecture.WebUI.Hubs
{
	public class GameHub : Hub//, IGameHub
	{
		private readonly IMediator _mediator;

		public GameHub(IMediator mediator)
		{
			_mediator = mediator;
		}

		protected Guid GameClientId
		{
			get => Guid.TryParse(Context.Items["GameClientId"]?.ToString(), out var clientId) ? clientId : Guid.Empty;
			set => Context.Items["GameClientId"] = value.ToString();
		}

		protected Guid PlayerClientId
		{
			get => Guid.TryParse(Context.Items["PlayerClientId"]?.ToString(), out var clientId) ? clientId : Guid.Empty;
			set => Context.Items["PlayerClientId"] = value.ToString();
		}

		public override async Task OnConnectedAsync()
		{
			await base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			if (GameClientId != Guid.Empty && PlayerClientId != Guid.Empty)
			{
				var @event = new UpdatePlayerStatusCommand
				{
					GameClientId = GameClientId,
					PlayerClientId = PlayerClientId,
					NewStatus = PlayerStatus.Disconnected
				};
				await _mediator.Send(@event);
			}

			await base.OnDisconnectedAsync(exception);
		}

		public async Task Subscribe(Guid gameClientId, Guid playerClientId)
		{
			GameClientId = gameClientId;
			PlayerClientId = playerClientId;

			var game = await _mediator.Send(new GetGameQuery
			{
				ClientId = gameClientId
			});

			if (game == null)
			{
				await SendClientErrorAsync("Game not found");
				return;
			}

			await Groups.AddToGroupAsync(Context.ConnectionId, game.Id.ToString());

			var @event = new UpdatePlayerStatusCommand
			{
				GameClientId = gameClientId,
				PlayerClientId = playerClientId,
				NewStatus = PlayerStatus.Connected
			};
			await _mediator.Send(@event);
		}

		public async Task SendMessage(GameDto game)
		{
			
			await Clients.All.SendAsync("ReceiveMessage", new GameDto
			{
				Name = game.Name + " 1",
				JoinCode = game.JoinCode + " 2"
			});
		}


		private Task SendClientErrorAsync(string message)
			=> Clients.Client(Context.ConnectionId).SendCoreAsync("Notification", new object[] { "Error", message });

		private Task SendClientNotificationAsync(string type, string message)
			=> Clients.Client(Context.ConnectionId).SendCoreAsync("Notification", new object[] { type, message });
		
    }
}
