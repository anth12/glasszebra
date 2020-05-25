import { GameDto, GamePlayerDto } from '@/client/api';

export interface PlayerUpdatedPublicEvent {
    gameId: number;
    playerId: number;
    player: GamePlayerDto;
}

export interface GameUpdatedPublicEvent {
    gameId: number;
    game: GameDto;
}