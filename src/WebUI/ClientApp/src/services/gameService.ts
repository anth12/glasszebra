import { GameDto } from '../client/api'
import { gameClient } from '@/client/api-factory';
import store from '../store';


export class GameService {

    loadGame(): Promise<GameDto> {
        const promise = new Promise<GameDto>((resolve, reject)=>{

            if (store.state.gameClientId == null)
                reject(new Error('Game not found'));
            
            console.log(`Loading existing game ${store.state.gameClientId}`);
            
            gameClient.get(store.state.gameClientId)
                .then(game => {
                    const playerExists = game.players?.some(p => p.id == store.state.playerId);

                    if (playerExists) {
                        store.dispatch('addGame', game);
                        resolve(game);
                    }
                    else {
                        store.dispatch('clear');
                        reject(new Error('Game not found'));
                    }
                }).catch(err=>{
                    reject(err);
                });
        });
        
        return promise;            
    }
}

export const gameService = new GameService();