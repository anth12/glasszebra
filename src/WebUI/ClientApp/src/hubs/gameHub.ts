import * as signalR from "@microsoft/signalr";
import { GameDto, GamePlayerDto } from '@/client/api';
import store from '@/store';
import { GameUpdatedPublicEvent, PlayerUpdatedPublicEvent } from './eventModels';

export class GameHub {
    connection: signalR.HubConnection;

    constructor(host = process.env.VUE_APP_API_BASEURL) {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(`${host}/gamehub`)
            .build();
    }

    connect(){
        
        this.connection.start()
        .then(()=>{

            const gameClientId = store.state.gameClientId;
            const playerClientId = store.state.playerClientId;
            console.debug(`Connected. Subscribing with clientId: ${gameClientId}`);
            this.connection.send("subscribe", gameClientId, playerClientId).then(() => {
                console.debug('Sent subscribe');
            });
        })
        .catch(err => console.log(err));

        this.connection.on("Notification", (type: string, message: string) => {
            alert(`[${type}] ${message}`);
        });

        this.connection.on("PlayerUpdatedPublicEvent", (event: PlayerUpdatedPublicEvent) => {
            console.debug('[Event] playerUpdatedPublicEvent', event);
            
            if(event.player != null)
                store.dispatch('updatePlayer', event.player);
            else
                store.dispatch('removePlayer', event.playerId)
        });

        this.connection.on("GameUpdatedPublicEvent", (event: GameUpdatedPublicEvent) => {
            console.debug('[Event] gameUpdatedPublicEvent', event);
            
            store.dispatch('updateGame', event.game);
        });
    }

    send(){
        const dto = new GameDto({
            name: 'Test Name',
            joinCode: 'Test Join Code',
        })
        this.connection.send("sendMessage", dto)
            .then(() => {
                console.log('Sent');
            });
    }
}
