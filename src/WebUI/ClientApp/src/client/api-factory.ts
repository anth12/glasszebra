import { GameClient, IGameClient, IPlayerClient, PlayerClient } from './api';

console.log(`Using api endpoint: ${process.env.VUE_APP_API_BASEURL}`)

export const gameClient: IGameClient = new GameClient(process.env.VUE_APP_API_BASEURL);
export const playerClient: IPlayerClient = new PlayerClient(process.env.VUE_APP_API_BASEURL);
