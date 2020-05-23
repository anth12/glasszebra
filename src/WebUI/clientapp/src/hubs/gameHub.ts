import * as signalR from "@microsoft/signalr";
import { GameDto, GamePlayerDto } from '@/client/api';
import store from '@/store';
import { GameUpdatedPublicEvent, PlayerUpdatedPublicEvent } from './eventModels';

export class GameHub {
    connection: signalR.HubConnection;

    constructor(host = "https://localhost:44312") {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(`${host}/gamehub`)
            .build();
    }

    connect(){

        console.log('connecting');
        
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

        this.connection.on("receiveMessage", (game: GameDto) => {
            console.debug('receeive');
            console.log(game);
        });

        this.connection.on("Notification", (type: string, message: string) => {
            alert(`[${type}] ${message}`);
        });

        this.connection.on("PlayerUpdatedPublicEvent", (event: PlayerUpdatedPublicEvent) => {
            console.debug('[Event] playerUpdatedPublicEvent', event);
            
            store.commit('updatePlayer', event.player);
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
