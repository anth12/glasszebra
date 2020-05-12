import * as signalR from "@microsoft/signalr";
import { GameDto } from '@/client/api';

export class GameHub {
    connection: signalR.HubConnection;

    constructor(host = "https://localhost:44312") {
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(`${host}/gamehub`)
            .build();
    }

    connect(){

        this.connection.start()
        .then(()=>{
            this.send();
        })
        .catch(err => console.log(err));

        this.connection.on("receiveMessage", (game: GameDto) => {
            console.log('receeive');
            console.log(game);
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
